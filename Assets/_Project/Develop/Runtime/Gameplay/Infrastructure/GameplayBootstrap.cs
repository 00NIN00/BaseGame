using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Gameplay.Core;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Gameplay.View;
using System.Collections;
using UnityEngine;
using System;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Meta.Features.Wallet;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        
        private TypingGameHandler _gameHandler;
        private GameCycle _gameCycle;
        private OutcomesCounterService _outcomesCounterService;
        private WalletService _walletService;
        
        private GameRewardHandler _rewardHandler;

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
            _gameHandler = new TypingGameHandler(_container.Resolve<IInput>());

            _gameCycle = new GameCycle(_container,  _gameHandler);
            
            _outcomesCounterService = _container.Resolve<OutcomesCounterService>();
            _walletService = _container.Resolve<WalletService>();

            _rewardHandler = new GameRewardHandler(_container);
            
           _viewTypingGameHandler.Initialize(_container.Resolve<IInput>());

            _container.Resolve<GeneratorSymbols.GeneratorSymbols>().LetterGenerated += _viewTypingGameHandler.DebugLetters;
           _gameCycle.Wined += _viewTypingGameHandler.Win;
           _gameCycle.Defeated += _viewTypingGameHandler.Defeat;
           
           _gameCycle.Wined += _rewardHandler.Win;
           _gameCycle.Defeated += _rewardHandler.Defeat;
           
           _gameCycle.Wined += _outcomesCounterService.AddWinner; 
           _gameCycle.Defeated += _outcomesCounterService.AddDefeated; 
           
            // Debug.Log("Initializing Gameplay Scene");
            
            yield break;
        }

        public override void Run()
        {
            Debug.Log("Start Gameplay Scene");
            
            _gameCycle.Start(_inputArgs);
        }
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinePerformer = _container.Resolve<ICoroutinesPerformer>();

                coroutinePerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
            }
        }

        private void OnDestroy()
        {
            _container.Resolve<GeneratorSymbols.GeneratorSymbols>().LetterGenerated -= _viewTypingGameHandler.DebugLetters;
            _gameCycle.Wined -= _viewTypingGameHandler.Win;
            _gameCycle.Defeated -= _viewTypingGameHandler.Defeat;
            
            _gameCycle.Wined -= _rewardHandler.Win;
            _gameCycle.Defeated -= _rewardHandler.Defeat;
            
            _gameCycle.Wined -= _outcomesCounterService.AddWinner; 
            _gameCycle.Defeated -= _outcomesCounterService.AddDefeated; 
        }
    }
}