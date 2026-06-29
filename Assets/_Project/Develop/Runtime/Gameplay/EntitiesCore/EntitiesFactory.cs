using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using _Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLiveContext _entitiesLiveContext;
        
        private readonly MonoEntitiesFactory _monoEntitiesFactory;
        
        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLiveContext = _container.Resolve<EntitiesLiveContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
        }
        
        public Entity CreateGhost(Vector3 position)
        {
            Entity entity = CreateEntity();
            
            _monoEntitiesFactory.Create(entity, position, "Entities/Ghost");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(360))
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new  ReactiveVariable<float>(100))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(2))
                .AddDeathProcessCurrentTime()
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

            entity
                .AddCanMove(canMove)
                .AddCanRotation(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                ;
            
            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new DeathSystem())
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