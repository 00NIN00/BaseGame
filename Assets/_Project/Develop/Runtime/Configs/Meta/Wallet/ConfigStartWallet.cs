using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(fileName = "ConfigStartWallet", menuName = "Configs/Meta/Wallet/NewConfigStartWallet", order = 0)]
    public class ConfigStartWallet : ScriptableObject
    {
        [SerializeField] private List<CurrencyConfig> _values;
        
        public int GetValueFor(CurrencyType type)
            => _values.First(config => config.Type == type).Value;
        
        [Serializable]
        private class CurrencyConfig
        {
            [field: SerializeField] public CurrencyType Type { get; private set; }
            
            [field: SerializeField] public int Value { get; private set; }
        }
    }
}