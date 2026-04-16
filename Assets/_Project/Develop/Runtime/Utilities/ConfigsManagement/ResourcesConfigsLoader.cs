using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Gameplay;
using _Project.Develop.Runtime.Gameplay.Configs;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Utilities.ConfigsManagement
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        private readonly ResourcesAssetsLouder _resourcesAssetsLouder;

        private readonly Dictionary<Type, string> _configsResourcesPaths = new()
        {
            { typeof(ConfigGameMode), "ConfigGameMode" },
            { typeof(ConfigGeneratorSymbols),  "ConfigGeneratorSymbols" },
            { typeof(ConfigStartWallet), "Configs/Meta/Wallet/StartWalletConfig" },
            {typeof(ConfigGameReward),  "Configs/Meta/ConfigGameReward" },
            {typeof(ConfigBuyReset), "Configs/Meta/ConfigBuyReset" },
        };
        
        public ResourcesConfigsLoader(ResourcesAssetsLouder resourcesAssetsLouder)
        {
            _resourcesAssetsLouder = resourcesAssetsLouder;
        }


        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoader)
        {
            Dictionary<Type, object> loadedConfigs = new();

            foreach (KeyValuePair<Type, string> configsResourcesPath in _configsResourcesPaths)
            {
                ScriptableObject config = _resourcesAssetsLouder.Load<ScriptableObject>(configsResourcesPath.Value);
                loadedConfigs.Add(configsResourcesPath.Key, config);
                yield return null;
            }
            
            onConfigsLoader?.Invoke(loadedConfigs);
        }
    }
}