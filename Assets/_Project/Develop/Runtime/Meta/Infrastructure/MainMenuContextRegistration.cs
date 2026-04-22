using _Project.Develop.Runtime.Gameplay;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Gameplay.View;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.OutcomesGame;
using _Project.Develop.Runtime.Meta.Features.ResetProgress;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Wallet;
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