using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Gameplay.Core;
using _Project.Develop.Runtime.Gameplay.View;
using System.Collections;
using UnityEngine;
using System;
using _Project.Develop.Runtime.Gameplay.Input;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        
        private TypingGameHandler _gameHandler;
        private GameCycle _gameCycle;

        private InitializationViewService  _initializationViewService;
        
        [SerializeField] private ViewTypingGameHandler _viewTypingGameHandler;

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
            _gameHandler = _container.Resolve<TypingGameHandler>();

            _gameCycle = _container.Resolve<GameCycle>();

            _initializationViewService = new InitializationViewService(_viewTypingGameHandler,
                _container.Resolve<IInput>(),
                _container.Resolve<GeneratorSymbols.GeneratorSymbols>(),
                _container.Resolve<GameCycle>() );
           
            // Debug.Log("Initializing Gameplay Scene");
            
            yield break;
        }

        public override void Run()
        {
            Debug.Log("Start Gameplay Scene");
            _initializationViewService.Initialize();   
            _gameCycle.Start(_inputArgs);
        }

        private void OnDestroy()
        {
            _initializationViewService.DeInitialize();
        }
    }
}