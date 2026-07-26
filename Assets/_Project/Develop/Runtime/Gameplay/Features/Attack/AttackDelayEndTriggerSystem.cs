using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class AttackDelayEndTriggerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _attackDelayEndEvent;
        private ReactiveVariable<float> _delay;
        private ReactiveVariable<float> _attackProcessCurrentTime;

        private ReactiveEvent _startAttackEvent;
        
        private bool _alreadyAttack;
        
        private IDisposable _timerDisposable;
        private IDisposable _startAttackDisposable;
        
        public void OnInit(Entity entity)
        {
            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _delay = entity.AttackDelayTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;
            _startAttackEvent = entity.StartAttackEvent;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnTimerChange);
            _startAttackDisposable = _startAttackEvent.Subscribe(OnStartAttack);
        }

        private void OnStartAttack()
        {
            _alreadyAttack = false;
        }

        private void OnTimerChange(float arg1, float currentTime)
        {
            if (_alreadyAttack)
                return;
            
            if (currentTime >= _delay.Value)
            {
                Debug.Log("задержка перед атакой закончилась");
                _attackDelayEndEvent.Invoke();
                _alreadyAttack =  true;
            }
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
            _startAttackDisposable.Dispose();
        }
    }
}