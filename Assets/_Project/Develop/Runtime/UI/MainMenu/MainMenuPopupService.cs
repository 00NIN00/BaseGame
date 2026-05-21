using _Project.Develop.Runtime.UI.Core;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPopupService : PopupService
    {
        private readonly MainMenuUIRoot _uiRoot;
        private readonly MainMenuPresentersFactory _mainMenuPresentsFactory;
        
        public MainMenuPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentsFactory presentsFactory,
            MainMenuUIRoot uiRoot,
            MainMenuPresentersFactory mainMenuPresentsFactory) 
            : base(viewsFactory, presentsFactory)
        {
            _uiRoot = uiRoot;
            _mainMenuPresentsFactory = mainMenuPresentsFactory;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;
    }
}