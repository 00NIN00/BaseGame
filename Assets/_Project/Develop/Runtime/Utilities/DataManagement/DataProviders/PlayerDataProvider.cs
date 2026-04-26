using System;
using _Project.Develop.Runtime.Utilities.DataManagement.DataRepository;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using System.Collections.Generic;
using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Utilities.DataManagement.DataProviders
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly ConfigsProviderService _configsProviderService;
        
        public PlayerDataProvider(ISaveLoadService saveLoadService, ConfigsProviderService configsProviderService) : base(saveLoadService)
        {
            _configsProviderService = configsProviderService;
        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData(),
                Counter = InitCounter(),
                CompletedLevels = new(),
            };
        }

        private Dictionary<OutcomesType, int> InitCounter()
        {
            Dictionary<OutcomesType, int> counterData = new();

            foreach (OutcomesType outcomesType in Enum.GetValues(typeof(OutcomesType)))
                counterData[outcomesType] = 0; 
            
            return counterData;
        }

        private Dictionary<CurrencyType, int> InitWalletData()
        {
            Dictionary<CurrencyType, int> walletData = new();
            
            ConfigStartWallet walletConfig = _configsProviderService.GetConfig<ConfigStartWallet>();
            
            
            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
                walletData[currencyType] = walletConfig.GetValueFor(currencyType); 
                // walletData.(currencyType, walletConfig.GetValueFor(currencyType));
            
            return walletData;
        }
    }
}