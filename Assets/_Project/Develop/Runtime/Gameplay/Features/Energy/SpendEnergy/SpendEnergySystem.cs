using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergy
{
    public class SpendEnergySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<float> _energyRequest;
        private ReactiveEvent<float> _energyEvent;

        private ReactiveVariable<float> _energy;

        private ICompositeCondition _canSpendEnergy;
        
        private IDisposable _requestDisposable;
        
        public void OnInit(Entity entity)
        {
            _energyEvent = entity.SpendEnergyEvent;
            _energyRequest = entity.SpendEnergyRequest;

            _energy = entity.CurrentEnergy;
            
            _canSpendEnergy = entity.CanSpendEnergy;

            _requestDisposable = _energyRequest.Subscribe(OnSpendEnergy);
        }
        
        public void OnDispose()
        {
            _requestDisposable.Dispose();
        }

        private void OnSpendEnergy(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            if (_energy.Value - value < 0)
                return;
            
            if(_canSpendEnergy.Evaluate() == false)
                return;
            
            _energy.Value = MathF.Max(_energy.Value - value, 0);
            _energyEvent.Invoke(value);
            Debug.Log($"потратил энергию, {_energy.Value}");
        }
    }
}