using _Project.Develop.Runtime.UI.Core;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPopupService : PopupService
    {
        private readonly MainMenuUIRoot _uiRoot;
        public MainMenuPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentsFactory presentsFactory, MainMenuUIRoot uiRoot) 
            : base(viewsFactory, presentsFactory)
        {
            _uiRoot = uiRoot;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;
    }
}