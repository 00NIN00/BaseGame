using _Project.Develop.Runtime.Configs.Meta;
using _Project.Develop.Runtime.Gameplay;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Gameplay.View;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

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
                c.Resolve<ResetProgressService>(),
                c.Resolve<ConfigsProviderService>());
        }

        private static ViewStats CreateViewStats(DIContainer c)
        {
            return new ViewStats(c.Resolve<WalletService>(), c.Resolve<OutcomesCounterService>());
        }
    }
}