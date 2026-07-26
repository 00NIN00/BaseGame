using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class AttackCancelSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _inAttackProcess;
        private ReactiveEvent _attackCanceledEvent;

        private ICompositeCondition _mustCancelAttack;
        
        public void OnInit(Entity entity)
        {
            _inAttackProcess = entity.InAttackProcess;
            _attackCanceledEvent = entity.AttackCancelEvent;

            _mustCancelAttack = entity.MustCancelAttack;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;
            
            
            if (_mustCancelAttack.Evaluate())
            {
                Debug.Log("Attack process прерван");
                _inAttackProcess.Value = false;
                _attackCanceledEvent.Invoke();
            }
        }
    }
}