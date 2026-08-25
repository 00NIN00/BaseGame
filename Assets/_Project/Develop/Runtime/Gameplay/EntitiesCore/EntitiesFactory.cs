using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using _Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage;
using _Project.Develop.Runtime.Gameplay.Features.Attack;
using _Project.Develop.Runtime.Gameplay.Features.Attack.Shoot;
using _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage;
using _Project.Develop.Runtime.Gameplay.Features.Energy;
using _Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergy;
using _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergy;
using _Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergy;
using _Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using _Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using _Project.Develop.Runtime.Gameplay.Features.Sensors;
using _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage;
using _Project.Develop.Runtime.Gameplay.Features.Teleport;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLiveContext _entitiesLiveContext;
        private readonly CollidersRegistryService _collidersRegistryService;
        private readonly MonoEntitiesFactory _monoEntitiesFactory;
        
        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLiveContext = _container.Resolve<EntitiesLiveContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
        }
        
        public Entity CreateHero(Vector3 position)
        {
            Entity entity = CreateEntity();
            
            _monoEntitiesFactory.Create(entity, position, "Entities/Hero");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(360))
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new  ReactiveVariable<float>(100))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(2))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(3))
                .AddAttackProcessCurrentTime()
                .AddInAttackProcess()
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddAttackDelayTime(new ReactiveVariable<float>(1))
                .AddAttackDelayEndEvent()
                .AddInstantAttackDamage(new ReactiveVariable<float>(50))
                .AddAttackCancelEvent()
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(2))
                .AddAttackCooldownCurrentTime()
                .AddInAttackCooldown()
                ;

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));
            
            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));
            
            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));
            
            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canCanStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.IsMoving.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false));
                
            ICompositeCondition mustCancelAttack = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.IsDead.Value == true))
                .Add(new FuncCondition(() => entity.IsMoving.Value == true));

            entity
                .AddCanMove(canMove)
                .AddCanRotation(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanStartAttack(canCanStartAttack)
                .AddMustCancelAttack(mustCancelAttack)
                ;
            
            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new AttackCancelSystem())
                .AddSystem(new StartAttackSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new InstantShootSystem(this))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLiveContext))
                ;
            
            _entitiesLiveContext.Add(entity);
            
            return entity;
        }
        
        public Entity CreateGhost(Vector3 position)
        {
            Entity entity = CreateEntity();
            
            _monoEntitiesFactory.Create(entity, position, "Entities/Ghost");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(360))
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new  ReactiveVariable<float>(100))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(2))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(50))
                ;

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));
            
            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));
            
            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));
            
            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotation(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage)
                ;
            
            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactDetectionSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLiveContext))
                ;
            
            _entitiesLiveContext.Add(entity);
            
            return entity;
        }
        
        public Entity CreateProjectile(Vector3 position, Vector3 direction, float damage)
        {
            Entity entity = CreateEntity();
            
            _monoEntitiesFactory.Create(entity, position, "Entities/Projectile");

            entity
                .AddMoveDirection(new ReactiveVariable<Vector3>(direction))
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddIsMoving()
                .AddRotationDirection(new ReactiveVariable<Vector3>(direction))
                .AddRotationSpeed(new ReactiveVariable<float>(999))
                .AddIsDead()
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(damage))
                .AddDeathMask(1 << LayerMask.NameToLayer("Characters"))
                .AddIsTouchDeathMask()
                ;

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));
            
            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsTouchDeathMask.Value));
            
            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));
            

            entity
                .AddCanMove(canMove)
                .AddCanRotation(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                ;
            
            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactDetectionSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLiveContext))
                ;
            
            _entitiesLiveContext.Add(entity);
            
            return entity;
        }
        
        public Entity CreateNewCharacter(Vector3 position)
        {
            Entity entity = CreateEntity();
            
            _monoEntitiesFactory.Create(entity, position, "Entities/NewCharacter");

            entity
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new  ReactiveVariable<float>(100))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(2))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(10))
                .AddMaxEnergy(new ReactiveVariable<float>(100))
                .AddCurrentEnergy(new ReactiveVariable<float>(100))
                .AddEnergyRegenIntervalInitialTime(new ReactiveVariable<float>(4))
                .AddEnergyRegenIntervalCurrentTime()
                .AddEnergyRegenPercentage(new ReactiveVariable<float>(10))
                .AddRegenEnergyRequest()
                .AddRegenEnergyEvent()
                .AddInEnergyRegenCooldown()
                .AddSpendEnergyRequest()
                .AddSpendEnergyEvent()
                .AddAddEnergyRequest()
                .AddAddEnergyEvent()
                .AddTeleportRadius(new ReactiveVariable<float>(1))
                .AddTeleportEnergyCost(new ReactiveVariable<float>(1))
                .AddTeleportCooldownInitialTime(new ReactiveVariable<float>(4))
                .AddTeleportCooldownCurrentTime(new ReactiveVariable<float>(4))
                .AddInTeleportCooldown()
                .AddSelectedTeleportPoint()
                .AddTeleportRequest()
                .AddTeleportPointSelectedEvent()
                .AddTeleportExecutedEvent()
                .AddAreaDamageAmount(new ReactiveVariable<float>(50))
                .AddAreaDamageRadius(new ReactiveVariable<float>(10))
                .AddAreaDamageRequest()
                .AddAreaDamageMask(1 << LayerMask.NameToLayer("Characters"))
                .AddAreaDamageContactsBuffer(new Buffer<Collider>(64))
                .AddAreaDamageTargetsBuffer(new Buffer<Entity>(64))
                ;

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));
            
            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));
            
            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));
            
            ICompositeCondition<float> canSpendEnergy = new CompositeCondition<float>()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.CurrentEnergy.Value > 0))
                .Add(new FuncCondition<float>(amount => entity.CurrentEnergy.Value >= amount))
                ;
            
            ICompositeCondition canAddEnergy = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.CurrentEnergy.Value < entity.MaxEnergy.Value));

            ICompositeCondition canRegenEnergy = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InEnergyRegenCooldown.Value == false));
            
            ICompositeCondition canTeleport = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.CurrentEnergy.Value >= entity.TeleportEnergyCost.Value))
                ;
            
            ICompositeCondition canAreaDamage = new CompositeCondition()
                    .Add(new FuncCondition(() => entity.IsDead.Value == false))
                ;
            
            entity
                .AddCanTeleport(canTeleport)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanSpendEnergy(canSpendEnergy)
                .AddCanRegenEnergy(canRegenEnergy)
                .AddCanAddEnergy(canAddEnergy)
                .AddCanAreaDamage(canAreaDamage)
                ;
            
            entity
                .AddSystem(new BodyContactDetectionSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new SpendEnergySystem())
                .AddSystem(new RegenEnergyProvokeSystem())
                .AddSystem(new RegenEnergySystem())
                .AddSystem(new EnergyRegenCooldownTimerSystem())
                .AddSystem(new AddEnergySystem())
                .AddSystem(new TeleportPointSelectionSystem())
                .AddSystem(new TeleportExecuteSystem())
                .AddSystem(new TeleportCooldownSystem())
                .AddSystem(new TeleportProvokeSystem())
                .AddSystem(new TeleportAreaDamageRequestSystem())
                .AddSystem(new AreaDamageDetectionSystem())
                .AddSystem(new AreaDamageEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DealAreaDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLiveContext))
                ;
            
            _entitiesLiveContext.Add(entity);
            
            return entity;
        }

        // public Entity CreateTestPlayerEntity(Vector3 position)
        // {
        //     Entity entity = CreateEntity();
        //     
        //     _monoEntitiesFactory.Create(entity, position, "Entities/Player");
        //
        //     entity
        //         .AddMoveDirection()
        //         .AddMoveSpeed(new ReactiveVariable<float>(10))
        //         .AddRotationDirection()
        //         .AddRotationSpeed(new ReactiveVariable<float>(360))
        //         ;
        //
        //     entity.AddSystem(new CharacterControllerMovementSystem());
        //     entity.AddSystem(new TransformRotationSystem());
        //     
        //     _entitiesLiveContext.Add(entity);
        //     
        //     return entity;
        // }
        
        private Entity CreateEntity() => new Entity();
    }
}