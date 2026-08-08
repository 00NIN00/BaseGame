using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage
{
    /// <summary>
    /// Приоритет для AreaDamage: 1
    /// </summary>
    public class AreaDamageDetectionSystem: IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private Buffer<Collider> _contacts;
        private Vector3? _pendingPosition;

        private ReactiveVariable<float> _radius;
        private LayerMask _mask;
        
        private ReactiveEvent<Vector3> _teleportEvent;
        
        private IDisposable _teleportEventDisposable;

        public void OnInit(Entity entity)
        {
            _contacts = entity.AreaDamageContactsBuffer;
            _radius = entity.AreaDamageRadius;
            _mask = entity.AreaDamageMask;
            _teleportEvent = entity.TeleportExecutedEvent;

            _teleportEventDisposable = _teleportEvent.Subscribe(OnTriggered);
        }

        public void OnDispose()
        {
            _teleportEventDisposable.Dispose();
        }
        
        private void OnTriggered(Vector3 position)
        {
            _pendingPosition = position;
        }

        public void OnUpdate(float deltaTime)
        {
            _contacts.Count = 0;

            if (_pendingPosition.HasValue == false)
                return;

            Vector3 position = _pendingPosition.Value;
            _pendingPosition = null;

            _contacts.Count = Physics.OverlapSphereNonAlloc(
                position,
                _radius.Value,
                _contacts.Items,
                _mask,
                QueryTriggerInteraction.Ignore);
        }

    }
}