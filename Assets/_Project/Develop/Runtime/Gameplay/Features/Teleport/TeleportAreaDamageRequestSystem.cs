using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportAreaDamageRequestSystem : IInitializableSystem
    {
        private ReactiveEvent<Vector3> _teleportEvent;
        private ReactiveEvent<Vector3> _areaDamageRequest;
        
        private IDisposable _teleportEventDisposable;
        
        public void OnInit(Entity entity)
        {
            _teleportEvent = entity.TeleportExecutedEvent;
            _areaDamageRequest = entity.AreaDamageRequest;
            
            _teleportEventDisposable = _teleportEvent.Subscribe(OnTeleportExecuted);
        }
        
        public void OnDispose()
        {
            _teleportEventDisposable?.Dispose();
        }

        private void OnTeleportExecuted(Vector3 position)
        {
            _areaDamageRequest.Invoke(position);
        }
    }
}