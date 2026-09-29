using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class FindLowestHpTeleportPoint : State, IFindTeleportPoint
    {
        private readonly Entity _entity;
        private readonly Transform _transform;
        private readonly ReactiveVariable<float> _teleportRadius;
        
        private readonly ReactiveVariable<Vector3> _selectedTeleportPoint;
        
        private readonly EntitiesLiveContext _entitiesLiveContext;

        public FindLowestHpTeleportPoint(Entity entity, EntitiesLiveContext entitiesLiveContext)
        {
            _entity = entity;
            _transform = entity.Transform;
            _teleportRadius = entity.TeleportRadius;
            
            _selectedTeleportPoint = entity.SelectedTeleportPoint;
            
            _entitiesLiveContext = entitiesLiveContext;
        }

        public override void Enter()
        {
            base.Enter();

            Entity target = FindLowestHpTarget();
            if (target == null)
                return;

            Vector3 direction = target.Transform.position - _transform.position;
            direction.y = 0f;

            Vector3 point = _transform.position + Vector3.ClampMagnitude(direction, _teleportRadius.Value);

            _selectedTeleportPoint.Value = point;
        }

        public void Update(float deltaTime) { }

        private Entity FindLowestHpTarget()
        {
            Entity selectedTarget = null;
            float lowestHp = float.PositiveInfinity;

            foreach (Entity target in _entitiesLiveContext.Entities)
            {
                if (CanSelectTarget(target) == false)
                    continue;

                float hp = target.CurrentHealth.Value;

                if (hp < lowestHp)
                {
                    lowestHp = hp;
                    selectedTarget = target;
                }
            }

            return selectedTarget;
        }
        
        private bool CanSelectTarget(Entity target)
        {
            if (target == _entity)
                return false;

            if (target.HasComponent<TakeDamageRequest>() == false)
                return false;

            if (target.TryGetCanApplyDamage(
                    out ICompositeCondition canApplyDamage))
            {
                return canApplyDamage.Evaluate();
            }

            return true;
        }
    }
}