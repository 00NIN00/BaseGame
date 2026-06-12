using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using System.Collections;
using UnityEngine;
using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        
        [SerializeField] private TestGameplay _testGameplay;
        private EntitiesLiveContext _entitiesLiveContext; 
        
        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {nameof(GameplayInputArgs)} type");
            
            _inputArgs = gameplayInputArgs;
            
            GameplayContextRegistration.Process(_container, _inputArgs);
        }
        
        public override IEnumerator Initialize()
        {
            _testGameplay.Initialize(_container);
            _entitiesLiveContext = _container.Resolve<EntitiesLiveContext>();
            yield break;
        }

        public override void Run()
        {
            _testGameplay.Run();
        }

        private void Update()
        {
            _entitiesLiveContext?.Update(Time.deltaTime);
        }

        private void OnDestroy()
        {
        }
    }
}