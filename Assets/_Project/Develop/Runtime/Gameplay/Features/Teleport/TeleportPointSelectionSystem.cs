using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;
using System;

using Random = UnityEngine.Random;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportPointSelectionSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _teleportRequest;
        private ReactiveVariable<Vector3> _selectedTeleportPoint;
        private ReactiveEvent<Vector3> _teleportPointSelectedEvent;
        
        private ReactiveVariable<float> _teleportRadius;
        private Transform _transform;
        
        private IDisposable _teleportRequestDisposable;

        public void OnInit(Entity entity)
        {
            _teleportRequest = entity.TeleportRequest;
            _selectedTeleportPoint = entity.SelectedTeleportPoint;
            _teleportPointSelectedEvent = entity.TeleportPointSelectedEvent;
            
            _teleportRadius = entity.TeleportRadius;
            _transform = entity.Transform;
            
            _teleportRequestDisposable = _teleportRequest.Subscribe(OnTeleportRequested);
        }

        public void OnDispose()
        {
            _teleportRequestDisposable.Dispose();
        }

        private void OnTeleportRequested()
        {
            Vector3 randomPoint = GetRandomPointInRadius(_transform.position, _teleportRadius.Value);
            _selectedTeleportPoint.Value = randomPoint;
            _teleportPointSelectedEvent.Invoke(randomPoint);
            
            Debug.Log($"Teleported to {_selectedTeleportPoint.Value}");
        }

        private Vector3 GetRandomPointInRadius(Vector3 center, float radius)
        {
            Vector2 randomCircle = Random.insideUnitCircle * radius;
            return center + new Vector3(randomCircle.x, 0, randomCircle.y);
        }
    }
}