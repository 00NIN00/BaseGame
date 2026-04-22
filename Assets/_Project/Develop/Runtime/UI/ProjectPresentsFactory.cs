using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Wallet;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.UI
{
    public class ProjectPresentsFactory
    {
        private readonly DIContainer _container;

        public ProjectPresentsFactory(DIContainer container)
        {
            _container = container;
        }

        public CurrencyPresenter CreateCurrencyPresenter(
            IconTextView view,
            IReadOnlyReactiveValue<int> currency,
            CurrencyType currencyType)
        {
            return new CurrencyPresenter(
                currency,
                currencyType,
                _container.Resolve<ConfigsProviderService>().GetConfig<ConfigCurrencyIcons>(),
                view);
        }

        public WalletPresenter CreateWalletPresenter(IconTextListView view)
        {
            return new WalletPresenter(
                view,
                _container.Resolve<ViewsFactory>(),
                this,
                _container.Resolve<WalletService>()); 
        }
    }
}