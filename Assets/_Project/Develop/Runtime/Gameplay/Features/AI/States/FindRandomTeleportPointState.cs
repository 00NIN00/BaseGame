using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class FindRandomTeleportPointState : State, IUpdatableState
    {
        private readonly Transform _transform;
        private readonly ReactiveVariable<float> _teleportRadius;
        private readonly ReactiveVariable<Vector3> _selectedTeleportPoint;

        public FindRandomTeleportPointState(Entity entity)
        {
            _transform = entity.Transform;
            _teleportRadius = entity.TeleportRadius;
            _selectedTeleportPoint = entity.SelectedTeleportPoint;
        }

        public override void Enter()
        {
            base.Enter();

            _selectedTeleportPoint.Value = GetRandomPointInRadius(_transform.position, _teleportRadius.Value);
        }
        
        private Vector3 GetRandomPointInRadius(Vector3 center, float radius)
        {
            Vector2 randomCircle = Random.insideUnitCircle * radius;
            return center + new Vector3(randomCircle.x, 0, randomCircle.y);
        }

        public void Update(float deltaTime)
        {
        }
    }
}