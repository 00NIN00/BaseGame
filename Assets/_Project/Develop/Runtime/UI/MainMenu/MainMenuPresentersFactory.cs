using _Project.Develop.Runtime.Infrastructure.DI;

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
            return new MainMenuScreenPresenter(view, _container.Resolve<ProjectPresentsFactory>());
        }
    }
}