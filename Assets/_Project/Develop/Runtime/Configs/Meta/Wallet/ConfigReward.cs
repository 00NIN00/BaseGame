using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(fileName = "ConfigReward", menuName = "Configs/Meta/Reward/NewConfigReward", order = 0)]
    public class ConfigReward : ScriptableObject
    {
        [SerializeField] private List<Reward> _rewards;
        
        public int GetReward(CurrencyType type)
            => _rewards.First(config => config.CurrencyType == type).RewardValue;

        public IReadOnlyList<CurrencyType> GetAllKeys() 
            => _rewards.Select(r => r.CurrencyType).ToList();
        
        [Serializable]
        private class Reward
        {
            [field: SerializeField] public CurrencyType CurrencyType { get; private set; }
            
            [field: SerializeField] public int RewardValue { get; private set; }
        }
        
        private void OnValidate()
        {
            var duplicates = _rewards
                .GroupBy(r => r.CurrencyType)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicates.Count > 0)
            {
                Debug.LogError($"Duplicate CurrencyType keys found: {string.Join(", ", duplicates)}", this);
            }
        }
    }
}