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
        
        private readonly TypingGameHandler _gameHandler;
        private GameplayInputArgs _inputArgs;

        private readonly GeneratorSymbols.GeneratorSymbols _generatorSymbols;
        private readonly ConfigsProviderService  _configsProviderService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly SceneSwitcherService  _sceneSwitcherService;
        
        private Coroutine _gameLoop;

        public GameCycle(TypingGameHandler gameHandler, GeneratorSymbols.GeneratorSymbols generatorSymbols, ConfigsProviderService configsProviderService, ICoroutinesPerformer coroutinesPerformer, SceneSwitcherService sceneSwitcherService)
        {
            _gameHandler = gameHandler;
            _generatorSymbols = generatorSymbols;
            _configsProviderService = configsProviderService;
            _coroutinesPerformer = coroutinesPerformer;
            _sceneSwitcherService = sceneSwitcherService;
        }

        public void Start(GameplayInputArgs inputArgs)
        {
            _inputArgs = inputArgs;
            
            ConfigGeneratorSymbols configGeneratorSymbols = _configsProviderService.GetConfig<ConfigGeneratorSymbols>();

            ConfigListSymbols configListSymbols = _configsProviderService.GetConfig<ConfigGameMode>()
                .GetConfigListSymbols(_inputArgs.GameMode);
            
            IEnumerable<char> letters = _generatorSymbols.Generate(
                configGeneratorSymbols.CountSymbols,
                configListSymbols.Symbols.ToArray()
            );

            
            _gameLoop = _coroutinesPerformer.StartPerform(_gameHandler.GameLoopCoroutine(letters));

            _gameHandler.LettersSequenceFinished += Win;
            _gameHandler.LetterMismatched += Defeat;
        }

        private void Win()
        {
            Wined?.Invoke();
            Stop();
            _coroutinesPerformer.StartPerform(Wait());
        }

        private IEnumerator Wait()
        {
            KeyCode keyCodeForMainMenu = KeyCode.Space;
            
            Debug.Log($"Press '{keyCodeForMainMenu}' to MainMenu");
            yield return new  WaitUntil(() => UnityEngine.Input.GetKeyDown(keyCodeForMainMenu));
            
            _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
        }

        private void Defeat()
        {
            Defeated?.Invoke();
            _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, _inputArgs));
            Stop();
        }

        private void Stop()
        {
            _coroutinesPerformer.StopPerform(_gameLoop);
            
            _gameHandler.LettersSequenceFinished -= Win;
            _gameHandler.LetterMismatched -= Defeat;
            _inputArgs = null;
        }
    }
}