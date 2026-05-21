using System.Collections.Generic;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.GeneratedText;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter: IPresenter
    {
        private readonly GameplayScreenView _screen;
        private readonly ProjectPresentsFactory _projectPresentsFactory;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private readonly GameplayPopupService _gameplayPopupService;
        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(ProjectPresentsFactory projectPresentsFactory, GameplayScreenView screen, GameplayPopupService gameplayPopupService, GameplayPresentersFactory gameplayPresentersFactory)
        {
            _projectPresentsFactory = projectPresentsFactory;
            _screen = screen;
            _gameplayPopupService = gameplayPopupService;
            _gameplayPresentersFactory = gameplayPresentersFactory;
        }

        public void Initialize()
        {
            CreateGeneratedText();
            
            foreach (IPresenter childPresenter in _childPresenters)
                childPresenter.Initialize();
        }


        public void Dispose()
        {
            foreach (IPresenter childPresenter in _childPresenters)
                childPresenter.Dispose();
            
            _childPresenters.Clear();
        }
        
        private void CreateGeneratedText()
        {
            GeneratedTextPresenter walletPresenter = _gameplayPresentersFactory.CreateGeneratedTextPresenter(_screen.GeneratedTextView);
            
            _childPresenters.Add(walletPresenter);
        }
    }
}