using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergy
{
    public class AddEnergySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<float> _energyRequest;
        private ReactiveEvent<float> _energyEvent;

        private ReactiveVariable<float> _energy;
        private ReactiveVariable<float> _energyMax;

        private ICompositeCondition _canAddEnergy;
        
        private IDisposable _requestDisposable;
        
        public void OnInit(Entity entity)
        {
            _energyEvent = entity.AddEnergyEvent;
            _energyRequest = entity.AddEnergyRequest;

            _energy = entity.CurrentEnergy;
            _energyMax = entity.MaxEnergy;
            
            _canAddEnergy = entity.CanAddEnergy;

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
            
            if(_canAddEnergy.Evaluate() == false)
                return;
            
            _energy.Value = MathF.Min(_energy.Value + value, _energyMax.Value);
            _energyEvent.Invoke(value);
            Debug.Log($"получил энергию, {_energy.Value}/{_energyMax.Value}");
        }
    }
}