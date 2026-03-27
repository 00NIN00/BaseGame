using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Develop.Runtime.Meta.Features;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(fileName = "ConfigGameReward", menuName = "Configs/Meta/Wallet/NewConfigGameReward", order = 0)]
    public class ConfigGameReward : ScriptableObject
    {
        [SerializeField] private List<Config> _configs;

        public ConfigReward GetConfigReward(OutcomesType gameMode)
            => _configs.First(config => config.OutcomesType == gameMode).ConfigReward;

        
        [Serializable]
        private class Config
        {
            [field: SerializeField] public OutcomesType OutcomesType { get; private set; }
            [field: SerializeField] public ConfigReward ConfigReward { get; private set; }
            
        }
        
        private void OnValidate()
        {
            var duplicates = _configs
                .GroupBy(r => r.OutcomesType)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicates.Count > 0)
                Debug.LogError($"Duplicate OutcomesType keys found: {string.Join(", ", duplicates)}", this);
        }
    }
}