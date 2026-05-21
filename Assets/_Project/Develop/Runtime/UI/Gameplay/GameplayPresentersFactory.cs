using _Project.Develop.Runtime.Infrastructure.DI;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }
        
        public GameplayScreenPresenter CreateMainMenuScreenPresenter(GameplayScreenView view)
        {
            return new GameplayScreenPresenter(
                _container.Resolve<ProjectPresentsFactory>(),
                view);
        }
    }
}