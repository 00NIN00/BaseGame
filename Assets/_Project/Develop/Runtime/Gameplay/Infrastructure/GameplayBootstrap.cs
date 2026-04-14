using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Gameplay.Core;
using System.Collections;
using UnityEngine;
using System;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        
        private GameCycle _gameCycle;
        private OutcomesCounterService _outcomesCounterService;
        
        private GameRewardHandler _rewardHandler;

        private InitializationViewService  _initializationViewService;

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
            _gameCycle = _container.Resolve<GameCycle>();
            
            _outcomesCounterService = _container.Resolve<OutcomesCounterService>();
            
            _rewardHandler = new GameRewardHandler(_container);
            
            _initializationViewService = _container.Resolve<InitializationViewService>();
           
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
            
            _initializationViewService.Initialize();   
            
            _gameCycle.Start(_inputArgs);
        }

        private void OnDestroy()
        {
            _initializationViewService.DeInitialize();
            
            _gameCycle.Wined -= _rewardHandler.Win;
            _gameCycle.Defeated -= _rewardHandler.Defeat;
            
            _gameCycle.Wined -= _outcomesCounterService.AddWinner; 
            _gameCycle.Defeated -= _outcomesCounterService.AddDefeated; 
        }
    }
}