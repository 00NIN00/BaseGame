using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class GameRewardHandler
    {
        private readonly ConfigsProviderService _configsProviderService;
        private readonly WalletService _walletService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly PlayerDataProvider _playerDataProvider;


        public GameRewardHandler(
            ConfigsProviderService  configsProviderService,
            WalletService walletService,
            ICoroutinesPerformer  coroutinesPerformer,
            PlayerDataProvider playerDataProvider)
        {
            _configsProviderService = configsProviderService;
            _walletService = walletService;
            _coroutinesPerformer = coroutinesPerformer;
            _playerDataProvider = playerDataProvider;
        }

        public void Win()
        {
            ConfigReward configReward = _configsProviderService.GetConfig<ConfigGameReward>()
                .GetConfigReward(OutcomesType.Win);
            
            
            foreach (CurrencyType currencyType in configReward.GetAllKeys())
            {
                _walletService.Add(
                    currencyType,
                    configReward.GetReward(currencyType));
            }
            
            _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
        }

        public void Defeat()
        {
            ConfigReward configReward = _configsProviderService.GetConfig<ConfigGameReward>()
                .GetConfigReward(OutcomesType.Defeat);
            
            
            foreach (CurrencyType currencyType in configReward.GetAllKeys())
            {
                if (_walletService.Enough(currencyType, configReward.GetReward(currencyType)))
                {
                    _walletService.Spend(
                        currencyType,
                        configReward.GetReward(currencyType));
                }
                else
                {
                    Debug.LogWarning("Not enough currency");
                }
            }
            
            _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
        }
    }
}