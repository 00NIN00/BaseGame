using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Utilities.DataManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.View
{
    public class ViewStats
    {
        private WalletService _walletService;
        private OutcomesCounterService _outcomesCounterService;
        
        public ViewStats(WalletService walletService, OutcomesCounterService outcomesCounterService)
        {
            _walletService = walletService;
            _outcomesCounterService = outcomesCounterService;
        }
        
        public void DebugStats()
        {
            Debug.Log("WALLET STATS");
            
            foreach (CurrencyType currencyType in _walletService.AvailableCurrencies)
                Debug.Log($"{currencyType}: {_walletService.GetCurrency(currencyType).Value}");                
   
            
            Debug.Log("OutcomesCounter STATS");
            foreach (OutcomesType outcomesType in _outcomesCounterService.AvailableOutcomes)
                Debug.Log($"{outcomesType}: {_outcomesCounterService.GetCount(outcomesType)}");                

        }
    }
}