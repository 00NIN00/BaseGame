using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;

        private Entity _entity;
        private Entity _entity2;
        
        private bool _isRunning;
        
        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run()
        {
            _entity = _entitiesFactory.CreateHero(Vector3.zero);
            _entitiesFactory.CreateGhost(Vector3.zero + Vector3.forward * 5);
            _entity2 = _entitiesFactory.CreateNewCharacter(Vector3.zero + Vector3.back * 5);
            // _entity = _entitiesFactory.CreateTestPlayerEntity(Vector3.zero);
            
            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning== false)
                return;

            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                _entity.TakeDamageRequest.Invoke(50);
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
                _entity.StartAttackRequest.Invoke();
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                _entity2.SpendEnergyRequest.Invoke(10);

            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("🔄 Запрос телепортации отправлен");
                _entity2.TeleportRequest.Invoke();
            }
            
            Vector3 inputDirection = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), 0, UnityEngine.Input.GetAxisRaw("Vertical"));
            
            _entity.MoveDirection.Value = inputDirection.normalized;
            _entity.RotationDirection.Value = inputDirection;
        }
    }
}