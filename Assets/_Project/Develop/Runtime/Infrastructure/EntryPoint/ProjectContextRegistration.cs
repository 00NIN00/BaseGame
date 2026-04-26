using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.Configs.Meta;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Meta.Features.LevelsProgression;
using _Project.Develop.Runtime.Meta.Features.OutcomesGame;
using _Project.Develop.Runtime.Meta.Features.ResetProgress;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.DataManagement.DataRepository;
using _Project.Develop.Runtime.Utilities.DataManagement.KeysStorage;
using _Project.Develop.Runtime.Utilities.DataManagement.Serializers;
using _Project.Develop.Runtime.Utilities.LoadingScreen;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class ProjectContextRegistration
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinesPerformer);
            container.RegisterAsSingle(CreateConfigsProviderService);
            container.RegisterAsSingle(CreateResourcesAssetsLouder);
            container.RegisterAsSingle(CreateSceneLoaderService);
            container.RegisterAsSingle(CreateSceneSwitcherService);
            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);
            container.RegisterAsSingle(CreateWalletService).NonLazy();
            container.RegisterAsSingle(CreateOutcomesCounterService).NonLazy();
            container.RegisterAsSingle(CreatePlayerDataProvider);
            container.RegisterAsSingle<ISaveLoadService>(CreateSaveLoadService);
            
            container.RegisterAsSingle<IInput>(CreateUserKeyBoardInput);
            container.RegisterAsSingle(CreateProjectPresentsFactory);
            container.RegisterAsSingle(CreateViewsFactory);
            container.RegisterAsSingle(CreateLevelsProgressionService).NonLazy();
        }

        private static LevelsProgressionService CreateLevelsProgressionService(DIContainer c)
            => new LevelsProgressionService(c.Resolve<PlayerDataProvider>());
        
        private static ViewsFactory CreateViewsFactory(DIContainer c)
            => new ViewsFactory(c.Resolve<ResourcesAssetsLouder>());

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer c)
            => new SceneSwitcherService(
                c.Resolve<SceneLoaderService>(),
                c.Resolve<ILoadingScreen>(),
                c);

        private static SceneLoaderService CreateSceneLoaderService(DIContainer c)
            => new SceneLoaderService();
        
        private static ResourcesAssetsLouder CreateResourcesAssetsLouder(DIContainer c)
            => new ResourcesAssetsLouder();
        
        private static CoroutinesPerformer CreateCoroutinesPerformer(DIContainer c)
        {
            ResourcesAssetsLouder resourcesAssetsLouder = c.Resolve<ResourcesAssetsLouder>();
            
            CoroutinesPerformer coroutinesPerformerPrefab = resourcesAssetsLouder
                .Load<CoroutinesPerformer>("Utilities/CoroutinesPerformer");

            return Object.Instantiate(coroutinesPerformerPrefab);
        }
        
        private static StandardLoadingScreen CreateLoadingScreen(DIContainer c)
        {
            ResourcesAssetsLouder resourcesAssetsLouder = c.Resolve<ResourcesAssetsLouder>();
            
            StandardLoadingScreen standardLoadingScreenPrefab = resourcesAssetsLouder
                .Load<StandardLoadingScreen>("Utilities/StandardLoadingScreen");

            return Object.Instantiate(standardLoadingScreenPrefab);
        }
        
        private static ConfigsProviderService CreateConfigsProviderService(DIContainer c)
        {
            ResourcesAssetsLouder resourcesAssetsLouder = c.Resolve<ResourcesAssetsLouder>();
            
            ResourcesConfigsLoader resourcesConfigsLoader = new ResourcesConfigsLoader(resourcesAssetsLouder);

            return new ConfigsProviderService(resourcesConfigsLoader);
        }

        private static WalletService CreateWalletService(DIContainer c)
        {
            Dictionary<CurrencyType, ReactiveVariable<int>> currencies = new();

            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
                currencies[currencyType] = new ReactiveVariable<int>();//can add a config to start with the values from the config
            
            return new WalletService(currencies, c.Resolve<PlayerDataProvider>());
        }

        private static SaveLoadService CreateSaveLoadService(DIContainer c)
        {
            IDataSerializer dataSerializer = new JsonSerializer();
            IDataKeysStorage dataKeysStorage = new MapDataKeysStorage();

            string saveFolderPath = Application.isEditor? Application.dataPath : Application.persistentDataPath;
            
            IDataRepository dataRepository = new LocalDataRepository(saveFolderPath, "json");
            
            return new SaveLoadService(dataSerializer, dataKeysStorage, dataRepository);
        }

        private static OutcomesCounterService CreateOutcomesCounterService(DIContainer c)
        {
            Dictionary<OutcomesType, int> outcomes = new();

            foreach (OutcomesType currencyType in Enum.GetValues(typeof(OutcomesType)))
                outcomes[currencyType] = 0;
            
            return new OutcomesCounterService(outcomes, c.Resolve<PlayerDataProvider>(), c.Resolve<ICoroutinesPerformer>());
        }
        
        private static PlayerDataProvider CreatePlayerDataProvider(DIContainer c)
            => new PlayerDataProvider(c.Resolve<ISaveLoadService>(), c.Resolve<ConfigsProviderService>());
        
        private static UserKeyBoardInput CreateUserKeyBoardInput(DIContainer c)
            => new UserKeyBoardInput();

        private static ProjectPresentsFactory CreateProjectPresentsFactory(DIContainer c)
            => new ProjectPresentsFactory(c);
    }
}