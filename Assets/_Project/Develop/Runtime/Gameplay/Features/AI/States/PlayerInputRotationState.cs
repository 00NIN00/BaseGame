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

        public PlayerInputRotationState(
            Entity entity,
            IInputService inputService,
            float mouseSensitivity = 2f,
            bool invertRotation = false)
        {
            _rotationDirection = entity.RotationDirection;
            _transform = entity.Transform;
            _inputService = inputService;

            _mouseSensitivity = mouseSensitivity * (invertRotation ? -1f : 1f);
        }

        public override void Enter()
        {
            base.Enter();

            _rotationDirection.Value = Vector3.zero;
        }

        public void Update(float deltaTime)
        {
            float angle = _inputService.RotationDelta * _mouseSensitivity;

            if (Mathf.Approximately(angle, 0f))
            {
                _rotationDirection.Value = Vector3.zero;
                return;
            }

            _rotationDirection.Value =
                Quaternion.AngleAxis(angle, Vector3.up) * _transform.forward;
        }

        public override void Exit()
        {
            base.Exit();

            _rotationDirection.Value = Vector3.zero;
        }
    }
}