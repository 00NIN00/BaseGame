using _Project.Develop.Runtime.Gameplay.GeneratorSymbols;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.GeneratedText;

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
                view,
                _container.Resolve<GameplayPopupService>(),
                this);
        }

        public GeneratedTextPresenter CreateGeneratedTextPresenter(TextView view)
        {
            return new GeneratedTextPresenter(
                view,
                _container.Resolve<GeneratorSymbols>(),
                _container.Resolve<IInput>());
        }
    }
}