using System.Collections.Generic;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Wallet;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screen;

        private readonly ProjectPresentsFactory _projectPresentsFactory;

        private readonly List<IPresenter> _childPresenters = new();
        
        public MainMenuScreenPresenter(MainMenuScreenView screen, ProjectPresentsFactory projectPresentsFactory)
        {
            _screen = screen;
            _projectPresentsFactory = projectPresentsFactory;
        }

        public void Initialize()
        {
            CreateWallet();
            
            foreach (IPresenter childPresenter in _childPresenters)
                childPresenter.Initialize();
        }

        public void Dispose()
        {
            foreach (IPresenter childPresenter in _childPresenters)
                childPresenter.Dispose();
            
            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentsFactory.CreateWalletPresenter(_screen.WalletView);
            
            _childPresenters.Add(walletPresenter);
        }
    }
}