using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.ResetProgress;
using _Project.Develop.Runtime.UI.ResetPopup;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenuScreenPresenter CreateMainMenuScreenPresenter(MainMenuScreenView view)
        {
            return new MainMenuScreenPresenter(
                view,
                _container.Resolve<ProjectPresentsFactory>(),
                _container.Resolve<MainMenuPopupService>());
        }
        
        public ResetPopupPresenter CreateResetPopupPresenter(ResetPopupView view)
        {
            return new ResetPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<PaidResetService>(),
                _container.Resolve<MainMenuPopupService>());
        }
    }
}