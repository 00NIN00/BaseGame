using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.AI.States;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.Timer;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI
{
    public class BrainsFactory
    {
        private readonly DIContainer _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainsContext _brainsContext;
        private readonly IInputService _inputService;
        private readonly EntitiesLiveContext _entitiesLiveContext;
        
        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _inputService = _container.Resolve<IInputService>();
            _entitiesLiveContext = _container.Resolve<EntitiesLiveContext>();
        }

        public StateMachineBrain CreateMainHeroBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine combatState = CreateAutoAttackStateMachine(entity);

            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);
            
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;
            
            ICompositeCondition fromMovementToCombatStateCondition = new CompositeCondition()
                .Add(new FuncCondition((() => currentTarget.Value != null)))
                .Add(new FuncCondition(() => _inputService.Direction == Vector3.zero));
            
            ICompositeCondition fromCombatToMovementStateCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => currentTarget.Value == null))
                .Add(new FuncCondition(() => _inputService.Direction != Vector3.zero));;

            AIStateMachine behavior = new AIStateMachine();
            
            behavior.AddState(movementState);
            behavior.AddState(combatState);
            
            behavior.AddTransition(movementState, combatState, fromMovementToCombatStateCondition);
            behavior.AddTransition(combatState, movementState, fromCombatToMovementStateCondition);

            FindTargetState findTargetState = new FindTargetState(entity, targetSelector, _entitiesLiveContext);
            AIParallelState parallelState = new AIParallelState(findTargetState, behavior);
            
            AIStateMachine rooStateMachine = new AIStateMachine();
            rooStateMachine.AddState(parallelState);
            
            StateMachineBrain brain = new StateMachineBrain(rooStateMachine);
            _brainsContext.SetFor(entity, brain);
            
            return brain;
        }
        
        public StateMachineBrain CreateGhostBrain(Entity entity)
        {
            AIStateMachine stateMachine = CrateRandomMovementStateMachine(entity);
            StateMachineBrain brain = new StateMachineBrain(stateMachine);
            
            _brainsContext.SetFor(entity, brain);
            
            return brain;
        }

        public StateMachineBrain CreateTeleportingCharacterBrain(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();
            
            EmptyState waitState = new EmptyState();
            TeleportState teleportState = new TeleportState(entity);
            AttackAfterTeleportState attackState = new AttackAfterTeleportState(entity);

            TimerService teleportTimer = _timerServiceFactory.Create(entity.TeleportCooldownInitialTime.Value);
            disposables.Add(teleportTimer);
            disposables.Add(waitState.Entered.Subscribe(teleportTimer.Restart));

            
            EventLatchCondition<Vector3> teleportExecutedCondition = new EventLatchCondition<Vector3>(entity.TeleportExecutedEvent);
            disposables.Add(teleportExecutedCondition);
            
            ICompositeCondition canStartTeleport = new CompositeCondition()
                .Add(new FuncCondition(() => teleportTimer.IsOver))
                .Add(entity.CanTeleport);
            
            AIStateMachine behavior = new AIStateMachine(disposables);
            
            behavior.AddState(waitState);
            behavior.AddState(teleportState);
            behavior.AddState(attackState);

            behavior.AddTransition(waitState, teleportState, canStartTeleport);
            behavior.AddTransition(teleportState, attackState, teleportExecutedCondition);
            behavior.AddTransition(attackState, waitState, new FuncCondition(() => true));

            StateMachineBrain brain = new StateMachineBrain(behavior);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }
        
        public AIStateMachine CrateRandomMovementStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();
            
            RandomMovementState randomMovementState = new RandomMovementState(entity, 0.5f);
            
            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(2f);
            disposables.Add(movementTimer);
            disposables.Add(randomMovementState.Entered.Subscribe(movementTimer.Restart));
            
            TimerService idleTimer = _timerServiceFactory.Create(3f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));
            
            FuncCondition movementTimerEndedCondition = new FuncCondition(() =>  movementTimer.IsOver);
            FuncCondition idleTimerEndedCondition = new FuncCondition(() =>  idleTimer.IsOver);
            
            AIStateMachine stateMachine = new AIStateMachine(disposables);
            
            stateMachine.AddState(randomMovementState);
            stateMachine.AddState(emptyState);
            
            stateMachine.AddTransition(randomMovementState, emptyState, movementTimerEndedCondition);
            stateMachine.AddTransition(emptyState, randomMovementState, idleTimerEndedCondition);
            
            return stateMachine;
        }

        private AIStateMachine CreateAutoAttackStateMachine(Entity entity)
        {
            RotateToTargetState rotateToTargetState = new RotateToTargetState(entity);
            
            AttackTriggerState attackTriggerState = new AttackTriggerState(entity);

            ICondition canAttack = entity.CanStartAttack;
            Transform transform = entity.Transform;
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromRotateToAttackCondition = new CompositeCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() =>
                {
                    Entity target = currentTarget.Value;

                    if (target == null)
                        return false;

                    float angleToTarget = Quaternion.Angle(transform.rotation,
                        Quaternion.LookRotation(target.Transform.position - transform.position));

                    return angleToTarget < 1f;
                }));

            ReactiveVariable<bool> inAttackProcess = entity.InAttackProcess;

            ICondition fromAttackToRotateStateCondition = new FuncCondition((() => inAttackProcess.Value == false));

            AIStateMachine stateMachine = new AIStateMachine();
            
            stateMachine.AddState(rotateToTargetState);
            stateMachine.AddState(attackTriggerState);
            
            stateMachine.AddTransition(rotateToTargetState, attackTriggerState, fromRotateToAttackCondition);
            stateMachine.AddTransition(attackTriggerState, rotateToTargetState, fromAttackToRotateStateCondition);
            
            return stateMachine;
        }
    }
}