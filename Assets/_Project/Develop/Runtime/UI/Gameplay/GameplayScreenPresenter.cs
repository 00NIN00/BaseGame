using System.Collections.Generic;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter: IPresenter
    {
        private readonly GameplayScreenView _screen;
        private readonly ProjectPresentsFactory _projectPresentsFactory;
        // private readonly MainMenuPopupService _menuPopupService;
        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(ProjectPresentsFactory projectPresentsFactory, GameplayScreenView screen)
        {
            _projectPresentsFactory = projectPresentsFactory;
            _screen = screen;
        }

        public void Initialize()
        {
            foreach (IPresenter childPresenter in _childPresenters)
                childPresenter.Initialize();
        }

        public void Dispose()
        {
            foreach (IPresenter childPresenter in _childPresenters)
                childPresenter.Dispose();
            
            _childPresenters.Clear();
        }
    }
}