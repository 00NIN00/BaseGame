using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportCooldownSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<bool> _inTeleportCooldown;
        private ReactiveEvent _teleportRequest;
        private ReactiveEvent<Vector3> _teleportExecutedEvent;
        
        private IDisposable _teleportRequestDisposable;
        private IDisposable _teleportExecutedEventDisposable;

        public void OnInit(Entity entity)
        {
            _currentTime = entity.TeleportCooldownCurrentTime;
            _initialTime = entity.TeleportCooldownInitialTime;
            _inTeleportCooldown = entity.InTeleportCooldown;
            _teleportRequest = entity.TeleportRequest;
            _teleportExecutedEvent = entity.TeleportExecutedEvent;
            
            _currentTime.Value = _initialTime.Value;
            
            _teleportExecutedEventDisposable = _teleportExecutedEvent.Subscribe(OnTeleportExecuted);
        }


        public void OnUpdate(float deltaTime)
        {
            if (_inTeleportCooldown.Value == false)
                return;
            
//            Debug.Log(_currentTime.Value);
            
            _currentTime.Value -= deltaTime;

            if (CooldownIsOver())
            {
                _currentTime.Value = _initialTime.Value;
                _inTeleportCooldown.Value = false;
            }
        }
        
        private void OnTeleportExecuted(Vector3 obj)
        {
            if (_inTeleportCooldown.Value == false)
            {
                _currentTime.Value = _initialTime.Value;
                _inTeleportCooldown.Value = true;
            }
        }

        private bool CooldownIsOver() => _currentTime.Value <= 0;
        
        public void OnDispose()
        {
            _teleportExecutedEventDisposable.Dispose();
        }
    }
}