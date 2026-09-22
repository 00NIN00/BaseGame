using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class AttackAfterTeleportState : State, IUpdatableState
    {
        private readonly ReactiveEvent<Vector3> _areaDamageRequest;
        private readonly ICompositeCondition _canAreaDamage;
        private readonly Transform _transform;

        public AttackAfterTeleportState(Entity entity)
        {
            _areaDamageRequest = entity.AreaDamageRequest;
            _canAreaDamage = entity.CanAreaDamage;
            _transform = entity.Transform;
        }

        public override void Enter()
        {
            base.Enter();

            if (_canAreaDamage.Evaluate())
                _areaDamageRequest.Invoke(_transform.position);
        }

        public void Update(float deltaTime) { }
    }
}