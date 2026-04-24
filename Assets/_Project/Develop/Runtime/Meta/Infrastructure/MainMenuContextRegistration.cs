using _Project.Develop.Runtime.Gameplay;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Gameplay.View;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.OutcomesGame;
using _Project.Develop.Runtime.Meta.Features.ResetProgress;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.MainMenu;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistration
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateSelectGameModeService);
            container.RegisterAsSingle(CreateMainMenuInputHandler);
            container.RegisterAsSingle(CreateViewStats);
            container.RegisterAsSingle(CreatePaidResetService);
            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateMaiMenuPopupService);
            // container.RegisterAsSingle(CreateWalletPresenter).NonLazy();
        }

        // private static WalletPresenter CreateWalletPresenter(DIContainer c)
        // {
        //     IconTextListView walletView = Object.FindObjectOfType<IconTextListView>();
        //     
        //     WalletPresenter walletPresenter = c.Resolve<ProjectPresentsFactory>().CreateWalletPresenter(walletView);
        //     
        //     return walletPresenter;
        // }

        private static MainMenuPopupService CreateMaiMenuPopupService(DIContainer c)
        {
            return new MainMenuPopupService(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentsFactory>(),
                c.Resolve<MainMenuUIRoot>());
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer c)
        {
            return new MainMenuPresentersFactory(c);
        }

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer c)
        {
            MainMenuUIRoot uiRoot = c.Resolve<MainMenuUIRoot>();
            
            MainMenuScreenView view = c.
                Resolve<ViewsFactory>().
                Create<MainMenuScreenView>(ViewIDs.MainMenuScreen, uiRoot.HUDLayer);
            
            MainMenuScreenPresenter presenter = c.
                Resolve<MainMenuPresentersFactory>().
                CreateMainMenuScreenPresenter(view);
            
            return presenter;
        }
        
        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer c)
        {
            ResourcesAssetsLouder resourcesAssetsLouder = c.Resolve<ResourcesAssetsLouder>();
            
            MainMenuUIRoot mainMenuUIRoot = resourcesAssetsLouder
                .Load<MainMenuUIRoot>("UI/MainMenu/MainMenuUIRoot");

            return Object.Instantiate(mainMenuUIRoot);
        }
        
        private static SelectGameModeService CreateSelectGameModeService(DIContainer c)
        {
            return new SelectGameModeService(c.Resolve<SceneSwitcherService>(), c.Resolve<ICoroutinesPerformer>());
        }

        private static MainMenuInputHandler CreateMainMenuInputHandler(DIContainer c)
        {
            return new MainMenuInputHandler(c.Resolve<IInput>(), c.Resolve<PaidResetService>(),c.Resolve<ViewStats>() );
        }

        private static PaidResetService CreatePaidResetService(DIContainer c)
        {
            return new PaidResetService(
                c.Resolve<WalletService>(),
                c.Resolve<OutcomesCounterService>(),
                c.Resolve<ConfigsProviderService>());
        }

        private static ViewStats CreateViewStats(DIContainer c)
        {
            return new ViewStats(c.Resolve<WalletService>(), c.Resolve<OutcomesCounterService>());
        }
    }
}