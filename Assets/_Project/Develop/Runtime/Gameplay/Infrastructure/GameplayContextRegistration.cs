using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Gameplay;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public static class GameplayContextRegistration
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateMaiMenuPopupService);
        }


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