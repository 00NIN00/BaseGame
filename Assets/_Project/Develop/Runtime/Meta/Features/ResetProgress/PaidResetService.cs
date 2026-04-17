using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Configs.Meta;
using _Project.Develop.Runtime.Gameplay.Configs;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class PaidResetService
    {
        private readonly WalletService _walletService;
        private readonly ResetProgressService _resetProgressService;
        private readonly ConfigsProviderService _configsProviderService;

        public PaidResetService(WalletService walletService, ResetProgressService resetProgressService, ConfigsProviderService configsProviderService)
        {
            _walletService = walletService;
            _resetProgressService = resetProgressService;
            _configsProviderService = configsProviderService;
        }

        public bool CanReset()
        {
            ConfigBuyReset config = _configsProviderService.GetConfig<ConfigBuyReset>();
            
            return _walletService.Enough(config.CurrencyType, config.Count);
        }

        public void Reset()
        {
            if (CanReset() == false)
                return;

            Debug.Log("Paid Reset");
            
            _resetProgressService.ResetPlayerData();
        }
    }
}