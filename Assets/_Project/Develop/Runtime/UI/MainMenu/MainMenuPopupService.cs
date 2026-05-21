using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.ResetPopup;
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
        
        public ResetPopupPresenter OpenResetPopup()
        {
            ResetPopupView view = ViewsFactory.Create<ResetPopupView>(ViewIDs.ResetPopupView, PopupLayer);
             
            ResetPopupPresenter popup = _mainMenuPresentsFactory.CreateResetPopupPresenter(view);
             
            OnPopupCreated(popup, view);
            
            return popup;
        }
    }
}