using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage
{
    /// <summary>
    /// Приоритет для AreaDamage: 3
    /// </summary>
    public class DealAreaDamageSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity> _targets;
        private ReactiveVariable<float> _damage;

        private ICompositeCondition _canAreaDamage;

        public void OnInit(Entity entity)
        {
            _targets = entity.AreaDamageTargetsBuffer;
            _damage = entity.AreaDamageAmount;
            _canAreaDamage = entity.CanAreaDamage;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canAreaDamage.Evaluate())
            {
                for (int i = 0; i < _targets.Count; i++)
                {
                    Entity target = _targets.Items[i];

                    if (target.HasComponent<TakeDamageRequest>())
                        target.TakeDamageRequest.Invoke(_damage.Value);
                }
            }
        }
    }
}