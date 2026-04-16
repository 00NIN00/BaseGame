using System;
using _Project.Develop.Runtime.Gameplay.Core;
using _Project.Develop.Runtime.Meta.Features;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayEventBindingService : IDisposable
    {
        private readonly GameCycle _gameCycle;
        private readonly OutcomesCounterService _outcomesCounterService;
        private readonly GameRewardHandler _rewardHandler;

        public GameplayEventBindingService(
            GameCycle gameCycle, 
            OutcomesCounterService outcomesCounterService, 
            GameRewardHandler rewardHandler)
        {
            _gameCycle = gameCycle;
            _outcomesCounterService = outcomesCounterService;
            _rewardHandler = rewardHandler;
        }

        public void Initialize()
        {
            _gameCycle.Wined += _rewardHandler.Win;
            _gameCycle.Defeated += _rewardHandler.Defeat;
           
            _gameCycle.Wined += OnWinCounted; 
            _gameCycle.Defeated += OnDefeatCounted; 
        }
        
        private void OnWinCounted() => _outcomesCounterService.AddOutcome(OutcomesType.Win);
        private void OnDefeatCounted() => _outcomesCounterService.AddOutcome(OutcomesType.Defeat);

        public void Dispose()
        {
            _gameCycle.Wined -= _rewardHandler.Win;
            _gameCycle.Defeated -= _rewardHandler.Defeat;
            
            _gameCycle.Wined -= OnWinCounted; 
            _gameCycle.Defeated -= OnDefeatCounted; 
        }
    }
}