using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
    public class EnergyRegenCooldownTimerSystem: IInitializableSystem, IUpdatableSystem, IDisposableSystem//TODO:что-то в этом скрипте не так проверить и дописать
    {
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<bool> _inRegenCooldown;
        
        private ReactiveEvent _energyRegenEvent;
        
        private IDisposable _energyRegenEventDisposable;

        public void OnInit(Entity entity)
        {
            _currentTime = entity.EnergyRegenIntervalCurrentTime;
            _initialTime = entity.EnergyRegenIntervalInitialTime;
            _energyRegenEvent = entity.RegenEnergyEvent;
            _inRegenCooldown = entity.InEnergyRegenCooldown;
            _currentTime.Value = _initialTime.Value;

            _energyRegenEventDisposable = _energyRegenEvent.Subscribe(OnRegenEnergy);
        }

        private void OnRegenEnergy()
        {
            _currentTime.Value = _initialTime.Value;
            _inRegenCooldown.Value = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inRegenCooldown.Value == false)
              return;
            
            _currentTime.Value -= deltaTime;
            
            if (TimerIsOver())
            {
                _inRegenCooldown.Value = false;
            }
        }

        private bool TimerIsOver() => _currentTime.Value <= 0;
        public void OnDispose()
        {
            _energyRegenEventDisposable?.Dispose();
        }
    }
}