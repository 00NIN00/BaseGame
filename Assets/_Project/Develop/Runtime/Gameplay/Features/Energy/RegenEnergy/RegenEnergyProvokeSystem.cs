using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergy
{
    public class RegenEnergyProvokeSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _inRegenEnergyCooldown;
        private ReactiveEvent _regenEnergyRequest;
        
        private ICompositeCondition _canRegenEnergy;
        
        
        public void OnInit(Entity entity)
        {
            _inRegenEnergyCooldown = entity.InEnergyRegenCooldown;
            _regenEnergyRequest = entity.RegenEnergyRequest;
            _canRegenEnergy = entity.CanRegenEnergy;

        }

        public void OnUpdate(float deltaTime)
        {
            if (_inRegenEnergyCooldown.Value )
                return;

            if (_canRegenEnergy.Evaluate() == false)
                return;
            
            _regenEnergyRequest.Invoke();
        }
    }
}