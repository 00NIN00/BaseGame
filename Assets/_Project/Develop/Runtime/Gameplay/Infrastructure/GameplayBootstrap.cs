using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Gameplay.Core;
using System.Collections;
using UnityEngine;
using System;
using _Project.Develop.Runtime.Gameplay.View;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        
        private GameCycle _gameCycle;

        // private InitializationViewService  _initializationViewService;
        private GameplayEventBindingService  _gameplayEventBindingService;

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
            // Debug.Log("Initializing Gameplay Scene");
            _gameCycle = _container.Resolve<GameCycle>();
            
            // _initializationViewService = _container.Resolve<InitializationViewService>();
            _gameplayEventBindingService = _container.Resolve<GameplayEventBindingService>();
            
            // _initializationViewService.Initialize();   
            _gameplayEventBindingService.Initialize();
            yield break;
        }

        public override void Run()
        {
            Debug.Log("Start Gameplay Scene");
            
            _gameCycle.Start(_inputArgs);
        }

        private void OnDestroy()
        {
            // _initializationViewService.Dispose();
            _gameplayEventBindingService.Dispose();
        }
    }
}