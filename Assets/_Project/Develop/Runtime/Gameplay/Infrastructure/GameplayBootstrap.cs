using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using System.Collections;
using UnityEngine;
using System;
using _Project.Develop.Runtime.Utilities.AssetsManagement;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        
        private TypingGameHandler _gameHandler;

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
            _gameHandler = new TypingGameHandler(
                _container.Resolve<IInput>()
                );
            
            _container.Resolve<GeneratorSymbols>().LetterGenerated += _viewTypingGameHandler.DebugLetters;//TODO:а отписаться где
            
           _viewTypingGameHandler.Initialize(_container.Resolve<IInput>());

           _gameHandler.LetterMismatched += _viewTypingGameHandler.Defeat;
           _gameHandler.LettersSequenceFinished += _viewTypingGameHandler.Win;
            
           _gameHandler.LetterMismatched += gameHandlerOnLetterMismatched;
           
            Debug.Log("Initializing Gameplay Scene");
            
            yield break;
        }

        private void gameHandlerOnLetterMismatched()
        {
            _container.Resolve<ICoroutinesPerformer>().StartPerform(_container.Resolve<SceneSwitcherService>().ProcessSwitchTo(Scenes.Gameplay, _inputArgs));
        }

        public override void Run()
        {
            Debug.Log("Start Gameplay Scene");
            
            var _generator = _container.Resolve<GeneratorSymbols>();
            
            var letters = _generator.Generate(
                _container.Resolve<ResourcesAssetsLouder>().Load<ConfigGeneratorSymbols>("ConfigGeneratorSymbols").CountSymbols,//TODO:переделать на конфиги 
                _inputArgs.ListSymbols.Symbols.ToArray()
                );
            
            _container.Resolve<ICoroutinesPerformer>().StartPerform(_gameHandler.GameLoopCoroutine(letters));
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinePerformer = _container.Resolve<ICoroutinesPerformer>();

                coroutinePerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
            }
        }

        private void OnDestroy()
        {
            _container.Resolve<GeneratorSymbols>().LetterGenerated -= _viewTypingGameHandler.DebugLetters;
            _gameHandler.LetterMismatched -= _viewTypingGameHandler.Defeat;
            _gameHandler.LettersSequenceFinished -= _viewTypingGameHandler.Win;
        }
    }
}