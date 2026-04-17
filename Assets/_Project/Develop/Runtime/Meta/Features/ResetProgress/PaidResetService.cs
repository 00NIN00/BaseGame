using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Meta.Features.OutcomesGame;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Gameplay.Configs;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Features.ResetProgress
{
    public class PaidResetService
    {
        private readonly WalletService _walletService;
        private readonly OutcomesCounterService _outcomesCounterService;
        private readonly ConfigsProviderService _configsProviderService;
        private ConfigBuyReset ConfigBuyReset => _configsProviderService.GetConfig<ConfigBuyReset>();


        public PaidResetService(WalletService walletService, OutcomesCounterService outcomesCounterService, ConfigsProviderService configsProviderService)
        {
            _walletService = walletService;
            _outcomesCounterService = outcomesCounterService;
            _configsProviderService = configsProviderService;
        }

        public bool CanReset()
        {
            return _walletService.Enough(ConfigBuyReset.CurrencyType, ConfigBuyReset.Count);
        }

        public void Reset()
        {
            if (CanReset() == false)
                return;
            
            _walletService.Spend(ConfigBuyReset.CurrencyType, ConfigBuyReset.Count);
            _outcomesCounterService.Reset();
            Debug.Log("Paid Reset");
        }
    }
}