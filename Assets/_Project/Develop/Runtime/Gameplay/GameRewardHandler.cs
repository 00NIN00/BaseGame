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
        private readonly DIContainer _container;

        public GameRewardHandler(DIContainer container)
        {
            _container = container;
        }

        public void Win()
        {
            ConfigReward configReward = _container.Resolve<ConfigsProviderService>().GetConfig<ConfigGameReward>()
                .GetConfigReward(OutcomesType.Win);
            
            
            foreach (CurrencyType currencyType in configReward.GetAllKeys())
            {
                _container.Resolve<WalletService>().Add(
                    currencyType,
                    configReward.GetReward(currencyType));
            }
            
            _container.Resolve<ICoroutinesPerformer>().StartPerform(_container.Resolve<PlayerDataProvider>().Save());
        }

        public void Defeat()
        {
            ConfigReward configReward = _container.Resolve<ConfigsProviderService>().GetConfig<ConfigGameReward>()
                .GetConfigReward(OutcomesType.Defeat);
            
            
            foreach (CurrencyType currencyType in configReward.GetAllKeys())
            {
                if (_container.Resolve<WalletService>().Enough(currencyType, configReward.GetReward(currencyType)))
                {
                    _container.Resolve<WalletService>().Spend(
                        currencyType,
                        configReward.GetReward(currencyType));
                }
                else
                {
                    Debug.LogWarning("Not enough currency");
                }
            }
            
            _container.Resolve<ICoroutinesPerformer>().StartPerform(_container.Resolve<PlayerDataProvider>().Save());
        }
    }
}