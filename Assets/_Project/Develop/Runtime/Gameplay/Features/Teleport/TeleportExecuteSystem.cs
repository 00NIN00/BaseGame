using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportExecuteSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _teleportRequest;
        private ReactiveVariable<Vector3>  _selectedTeleportPoint;
        private ReactiveEvent<Vector3> _teleportExecutedEvent;
        
        private ICompositeCondition _canTeleport;

        private ReactiveVariable<float> _teleportEnergyCost;

        private ReactiveEvent<float> _spendEnergyRequest;

        private Transform _transform;

        private IDisposable _teleportPointSelectedDisposable;

        public void OnInit(Entity entity)
        {
            _teleportRequest = entity.TeleportRequest;

            _selectedTeleportPoint = entity.SelectedTeleportPoint;
            
            _teleportExecutedEvent = entity.TeleportExecutedEvent;
        
            _canTeleport = entity.CanTeleport;

            _teleportEnergyCost = entity.TeleportEnergyCost;

            _spendEnergyRequest = entity.SpendEnergyRequest;

            _transform = entity.Transform;

            _teleportPointSelectedDisposable = _teleportRequest.Subscribe(OnTeleportPointSelected);
        }

        public void OnDispose()
        {
            _teleportPointSelectedDisposable.Dispose();
        }

        private void OnTeleportPointSelected()
        {
            if (_canTeleport.Evaluate())
            {
                _transform.position = _selectedTeleportPoint.Value;

                _spendEnergyRequest.Invoke(_teleportEnergyCost.Value);
                
                _teleportExecutedEvent.Invoke(_selectedTeleportPoint.Value);
            }
        }
    }
}