using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class TransformRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _rotationSpeed;
        private ReactiveVariable<Vector3> _rotationDirection;
        private Transform _transform;

        public void OnInit(Entity entity)
        {
            _rotationSpeed = entity.RotationSpeed;
            _rotationDirection = entity.RotationDirection;
            _transform = entity.Transform;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_rotationDirection.Value == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_rotationDirection.Value);
            
            Quaternion newRotation = Quaternion.Lerp(
                _transform.rotation,
                targetRotation,
                _rotationSpeed.Value * deltaTime
            );

            _transform.rotation = targetRotation;
        }
    }
}