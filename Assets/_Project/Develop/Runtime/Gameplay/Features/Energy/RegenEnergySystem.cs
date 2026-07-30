using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
    public class RegenEnergySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _maxEnergy;
        private ReactiveVariable<float> _regenPercentage;
        private ReactiveEvent _energyRegenEvent;
        private ReactiveEvent<float> _addEnergyRequest;

        private IDisposable _energyRegenEventDisposable;

        public void OnInit(Entity entity)
        {
            _maxEnergy = entity.MaxEnergy;
            _regenPercentage = entity.EnergyRegenPercentage;
            _energyRegenEvent = entity.RegenEnergyEvent;
            _addEnergyRequest = entity.AddEnergyRequest;

            _energyRegenEventDisposable = _energyRegenEvent.Subscribe(OnEnergyRegenTriggered);
        }

        private void OnEnergyRegenTriggered()
        {
            float regenAmount = _maxEnergy.Value * (_regenPercentage.Value / 100f);
            
            Debug.Log("Regen amount is " + regenAmount);
            
            _addEnergyRequest.Invoke(regenAmount);
        }


        public void OnDispose()
        {
            _energyRegenEventDisposable.Dispose();
        }
    }
}