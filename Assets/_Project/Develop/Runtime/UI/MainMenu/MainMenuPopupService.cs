using _Project.Develop.Runtime.UI.Core;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPopupService : PopupService
    {
        private readonly MainMenuUIRoot _uiRoot;
        public MainMenuPopupService(
            ViewsFactory viewFactory,
            ProjectPresentsFactory presentsFactory, MainMenuUIRoot uiRoot) 
            : base(viewFactory, presentsFactory)
        {
            _uiRoot = uiRoot;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;
    }
}