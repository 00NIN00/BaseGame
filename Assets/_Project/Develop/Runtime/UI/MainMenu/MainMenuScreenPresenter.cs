using System.Collections.Generic;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Wallet;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screen;

        private readonly ProjectPresentsFactory _projectPresentsFactory;

        private readonly MainMenuPopupService _menuPopupService;
        
        private readonly List<IPresenter> _childPresenters = new();
        
        public MainMenuScreenPresenter(
            MainMenuScreenView screen,
            ProjectPresentsFactory projectPresentsFactory,
            MainMenuPopupService menuPopupService)
        {
            _screen = screen;
            _projectPresentsFactory = projectPresentsFactory;
            _menuPopupService = menuPopupService;
        }

        public void Initialize()
        {
            _screen.OpenLevelsMenuButtonClicked += OnOpenLevelsMenuButtonClicked;
            
            CreateWallet();
            
            foreach (IPresenter childPresenter in _childPresenters)
                childPresenter.Initialize();
        }


        public void Dispose()
        {
            _screen.OpenLevelsMenuButtonClicked += OnOpenLevelsMenuButtonClicked;
            
            foreach (IPresenter childPresenter in _childPresenters)
                childPresenter.Dispose();
            
            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentsFactory.CreateWalletPresenter(_screen.WalletView);
            
            _childPresenters.Add(walletPresenter);
        }
        
        private void OnOpenLevelsMenuButtonClicked()
        {
            _menuPopupService.OpenLevelsMenuPopup();
        }
    }
}