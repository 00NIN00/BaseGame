using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class PlayerInputRotationState : State, IUpdatableState
    {
        private readonly IInputService _inputService;
        private readonly ReactiveVariable<Vector3> _rotationDirection;
        private readonly Transform _transform;
        private readonly float _mouseSensitivity;

        private Vector3 _direction;

        public PlayerInputRotationState(Entity entity, IInputService inputService, float mouseSensitivity = 1f)
        {
            _rotationDirection = entity.RotationDirection;
            _transform = entity.Transform;
            
            _inputService = inputService;
            _mouseSensitivity = mouseSensitivity;
        }

        public override void Enter()
        {
            base.Enter();

            _direction = _transform.forward;
            _rotationDirection.Value = _direction;
        }

        public void Update(float deltaTime)
        {
            float angle = _inputService.RotationDelta * _mouseSensitivity;

            _direction = Quaternion.AngleAxis(angle, Vector3.up) * _direction;
            _rotationDirection.Value = _direction;
        }

        public override void Exit()
        {
            base.Exit();

            _rotationDirection.Value = Vector3.zero;
        }
    }
}