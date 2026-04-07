using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Gameplay.Configs;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using System.Linq;

namespace _Project.Develop.Runtime.Gameplay.Core
{
    public class GameCycle
    {
        public event Action Wined;
        public event Action Defeated;
        
        private readonly DIContainer _container;
        private readonly TypingGameHandler _gameHandler;
        private GameplayInputArgs _inputArgs;
        
        private Coroutine _gameLoop;

        public GameCycle(DIContainer container, TypingGameHandler gameHandler)
        {
            _container = container;
            _gameHandler = gameHandler;
        }

        public void Start(GameplayInputArgs inputArgs)
        {
            _inputArgs = inputArgs;
            
            GeneratorSymbols.GeneratorSymbols generator = _container.Resolve<GeneratorSymbols.GeneratorSymbols>();
            
            ConfigGeneratorSymbols configGeneratorSymbols = _container.Resolve<ConfigsProviderService>().GetConfig<ConfigGeneratorSymbols>();

            ConfigListSymbols configListSymbols = _container.Resolve<ConfigsProviderService>().GetConfig<ConfigGameMode>()
                .GetConfigListSymbols(_inputArgs.GameMode);
            
            IEnumerable<char> letters = generator.Generate(
                configGeneratorSymbols.CountSymbols,
                configListSymbols.Symbols.ToArray()
            );

            
            _gameLoop = _container.Resolve<ICoroutinesPerformer>().StartPerform(_gameHandler.GameLoopCoroutine(letters));

            _gameHandler.LettersSequenceFinished += Win;
            _gameHandler.LetterMismatched += Defeat;
        }

        private void Win()
        {
            Wined?.Invoke();
            Stop();
            _container.Resolve<ICoroutinesPerformer>().StartPerform(Wait());
        }

        private IEnumerator Wait()
        {
            KeyCode keyCodeForMainMenu = KeyCode.Space;
            
            Debug.Log($"Press '{keyCodeForMainMenu}' to MainMenu");
            yield return new  WaitUntil(() => UnityEngine.Input.GetKeyDown(keyCodeForMainMenu));
            
            _container.Resolve<ICoroutinesPerformer>().StartPerform(_container.Resolve<SceneSwitcherService>().ProcessSwitchTo(Scenes.MainMenu));
        }

        private void Defeat()
        {
            Defeated?.Invoke();
            _container.Resolve<ICoroutinesPerformer>().StartPerform(_container.Resolve<SceneSwitcherService>().ProcessSwitchTo(Scenes.Gameplay, _inputArgs));
            Stop();
        }

        private void Stop()
        {
            _container.Resolve<ICoroutinesPerformer>().StopPerform(_gameLoop);
            
            _gameHandler.LettersSequenceFinished -= Win;
            _gameHandler.LetterMismatched -= Defeat;
            _inputArgs = null;
        }
    }
}