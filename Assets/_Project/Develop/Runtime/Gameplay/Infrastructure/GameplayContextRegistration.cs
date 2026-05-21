using _Project.Develop.Runtime.Gameplay.Core;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Gameplay.View;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Meta.Features.OutcomesGame;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Gameplay;
using _Project.Develop.Runtime.UI.MainMenu;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public static class GameplayContextRegistration
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            // Debug.Log("Process registration service on scene Gameplay");
            container.RegisterAsSingle(CreateGeneratorLetters);
            container.RegisterAsSingle(CreateTypingGameHandler);
            container.RegisterAsSingle(CreateHameCycle);
            // container.RegisterAsSingle(CreateInitializationViewService);
            container.RegisterAsSingle(CreateGameRewardHandler);
            container.RegisterAsSingle(CreateGameplayEventBindingService);
            
            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateMaiMenuPopupService);
        }

        private static GeneratorSymbols.GeneratorSymbols CreateGeneratorLetters(DIContainer c)
            => new GeneratorSymbols.GeneratorSymbols();

        private static TypingGameHandler CreateTypingGameHandler(DIContainer c)
            =>  new TypingGameHandler(c.Resolve<IInput>());
        
        private static GameCycle CreateHameCycle(DIContainer c)
            =>  new GameCycle(
                c.Resolve<TypingGameHandler>(),
                c.Resolve<GeneratorSymbols.GeneratorSymbols>(),
                c.Resolve<ConfigsProviderService>(),
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<SceneSwitcherService>());

        // private static InitializationViewService CreateInitializationViewService(DIContainer c)
        // {
        //     ResourcesAssetsLouder resourcesAssetsLouder = c.Resolve<ResourcesAssetsLouder>();
        //     
        //     ViewTypingGameHandler viewTypingGameHandlerPrefab = resourcesAssetsLouder
        //         .Load<ViewTypingGameHandler>("View");
        //
        //     ViewTypingGameHandler viewTypingGameHandler = Object.Instantiate(viewTypingGameHandlerPrefab);
        //     
        //     
        //     InitializationViewService initializationViewService = new InitializationViewService(viewTypingGameHandler,
        //         c.Resolve<IInput>(),
        //         c.Resolve<GeneratorSymbols.GeneratorSymbols>(),
        //         c.Resolve<GameCycle>() );
        //
        //     return initializationViewService;
        // }

        private static GameRewardHandler CreateGameRewardHandler(DIContainer c)
        {
            return new GameRewardHandler(
                c.Resolve<ConfigsProviderService>(),
                c.Resolve<WalletService>(),
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<PlayerDataProvider>());
        }
        private static GameplayEventBindingService CreateGameplayEventBindingService(DIContainer c)
        {
            return new GameplayEventBindingService(
                c.Resolve<GameCycle>(),
                c.Resolve<OutcomesCounterService>(),
                c.Resolve<GameRewardHandler>());
        }
        
        private static GameplayUIRoot CreateMainMenuUIRoot(DIContainer c)
        {
            ResourcesAssetsLouder resourcesAssetsLouder = c.Resolve<ResourcesAssetsLouder>();
            
            GameplayUIRoot gameplayUIRoot = resourcesAssetsLouder
                .Load<GameplayUIRoot>("UI/Gameplay/GameplayUIRoot");

            return Object.Instantiate(gameplayUIRoot);
        }
        
        private static GameplayPresentersFactory CreateMainMenuPresentersFactory(DIContainer c)
        {
            return new GameplayPresentersFactory(c);
        }
        
        private static GameplayScreenPresenter CreateMainMenuScreenPresenter(DIContainer c)
        {
            GameplayUIRoot uiRoot = c.Resolve<GameplayUIRoot>();
            
            GameplayScreenView view = c.
                Resolve<ViewsFactory>().
                Create<GameplayScreenView>(ViewIDs.GameplayScreen, uiRoot.HUDLayer);
            
            GameplayScreenPresenter presenter = c.
                Resolve<GameplayPresentersFactory>().
                CreateMainMenuScreenPresenter(view);
            
            return presenter;
        }
        
        private static GameplayPopupService CreateMaiMenuPopupService(DIContainer c)
        {
            return new GameplayPopupService(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentsFactory>(),
                c.Resolve<GameplayUIRoot>(),
                c.Resolve<GameplayPresentersFactory>());
        }
        /*
        
        private static TypingGameHandler CreateTypingGameHandler(DIContainer c)
        {
            IInput input = c.Resolve<IInput>();
            
            return new TypingGameHandler();
        }
        
        */
    }
}