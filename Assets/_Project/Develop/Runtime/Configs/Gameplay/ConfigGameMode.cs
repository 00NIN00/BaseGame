using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Configs
{
    [CreateAssetMenu(menuName = "Configs/ConfigGameMode", fileName = "ConfigGameMode", order = 0)]
    public class ConfigGameMode : ScriptableObject
    {
        [SerializeField] private List<Config> _configs;

        public ConfigListSymbols GetConfigListSymbols(GameMode gameMode)
            => _configs.First(config => config.GameMode == gameMode).ConfigListSymbols;

        [Serializable]
        private class Config
        {
            [field: SerializeField] public GameMode GameMode { get; private set; }
            [field: SerializeField] public ConfigListSymbols ConfigListSymbols { get; private set; }
            
        }
    }
}