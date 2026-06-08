using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using System.Collections;
using UnityEngine;
using System;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        
        [SerializeField] private TestGameplay _testGameplay;

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
            yield break;
        }

        public override void Run()
        {
            _testGameplay.Run();
        }

        private void OnDestroy()
        {
        }
    }
}