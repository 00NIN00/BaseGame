using _Project.Develop.Runtime.Meta.Features.Wallet;
using System.Collections.Generic;
using _Project.Develop.Runtime.Meta.Features;

namespace _Project.Develop.Runtime.Utilities.DataManagement
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrencyType, int> WalletData;
        public Dictionary<OutcomesType, int> Counter;
    }
}