using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergy
{
    public class RegenEnergySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _maxEnergy;
        private ReactiveVariable<float> _regenPercentage;
        private ReactiveEvent _energyRegenEvent;
        private ReactiveEvent _energyRegenRequest;
        private ReactiveEvent<float> _addEnergyRequest;

        private IDisposable _energyRegenRequestDisposable;

        public void OnInit(Entity entity)
        {
            _maxEnergy = entity.MaxEnergy;
            _regenPercentage = entity.EnergyRegenPercentage;
            _energyRegenRequest = entity.RegenEnergyRequest;
            _energyRegenEvent = entity.RegenEnergyEvent;
            _addEnergyRequest = entity.AddEnergyRequest;

            _energyRegenRequestDisposable = _energyRegenRequest.Subscribe(OnEnergyRegenTriggered);
        }

        private void OnEnergyRegenTriggered()
        {
            float regenAmount = _maxEnergy.Value * (_regenPercentage.Value / 100f);
            
            _addEnergyRequest.Invoke(regenAmount);
            
            _energyRegenEvent.Invoke();
        }


        public void OnDispose()
        {
            _energyRegenRequestDisposable.Dispose();
        }
    }
}