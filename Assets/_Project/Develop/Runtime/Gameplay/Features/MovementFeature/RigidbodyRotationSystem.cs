using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _rotationSpeed;
        private ReactiveVariable<Vector3> _rotationDirection;
        private Rigidbody _rigidbody;
        
        private ICompositeCondition _canRotation;
        
        public void OnInit(Entity entity)
        {
            _rotationSpeed = entity.RotationSpeed;
            _rotationDirection = entity.RotationDirection;
            _rigidbody = entity.Rigidbody;
            
            _canRotation = entity.CanRotation;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotation.Evaluate() == false)
                return;
            
            if (_rotationDirection.Value == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_rotationDirection.Value);
            
            float step = _rotationSpeed.Value * deltaTime;
            
            Quaternion rotation = Quaternion.RotateTowards(_rigidbody.rotation, targetRotation, step);
            
            _rigidbody.MoveRotation(rotation);
        }
    }
}