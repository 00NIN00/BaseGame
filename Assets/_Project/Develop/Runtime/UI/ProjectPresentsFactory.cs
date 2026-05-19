using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Meta.Features.LevelsProgression;
using _Project.Develop.Runtime.Meta.Features.OutcomesGame;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.LevelsMenuPopup;
using _Project.Develop.Runtime.UI.OutcomesCounter;
using _Project.Develop.Runtime.UI.Wallet;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.SceneManagement;

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

        public TestPopupPresenter CreateTestPopupPresenter(TestPopupView view)
        {
            return new TestPopupPresenter(
                view,
                _container.Resolve<ICoroutinesPerformer>());
        }

        public LevelTitlePresenter CreateLevelTitlePresenter(LevelTitleView view, int levelNumber)
        {
            return new LevelTitlePresenter(
                _container.Resolve<LevelsProgressionService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<SceneSwitcherService>(),
                levelNumber,
                view);
        }

        public LevelsMenuPopupPresenter CreateLevelsMenuPopupPresenter(LevelsMenuPopupView view)
        {
            return new LevelsMenuPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<ConfigsProviderService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view);
        }

        public OutcomesPresenter CreateOutcomesPresenter(
            IReadOnlyReactiveValue<int> outcomes,
            OutcomesType outcomesType,
            TextAndTextView view)
        {
            return new OutcomesPresenter(
                outcomes,
                outcomesType,
                view);
        }

        public OutcomesCounterPresenter CreateOutcomesCounterPresenter(TextAndTextListView view)
        {
            return new OutcomesCounterPresenter(
                _container.Resolve<OutcomesCounterService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view);
        }
    }
}