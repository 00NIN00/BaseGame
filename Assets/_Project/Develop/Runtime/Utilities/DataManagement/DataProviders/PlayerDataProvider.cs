using _Project.Develop.Runtime.Utilities.DataManagement.DataRepository;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Utilities.DataManagement.DataProviders
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        public PlayerDataProvider(ISaveLoadService saveLoadService) : base(saveLoadService)
        {
        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData(),
            };
        }

        private Dictionary<CurrencyType, int> InitWalletData()
        {
            Dictionary<CurrencyType, int> walletData = new();
            
            walletData.Add(CurrencyType.Gold, 100);
            walletData.Add(CurrencyType.Diamond, 20);
            
            return walletData;
        }
    }
}