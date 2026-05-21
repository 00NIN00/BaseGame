using _Project.Develop.Runtime.Meta.Features.ResetProgress;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.MainMenu;
using _Project.Develop.Runtime.UI.TextPopup;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;

namespace _Project.Develop.Runtime.UI.ResetPopup
{
    public class ResetPopupPresenter : PopupPresenterBase
    {
        private const string Title = "Do you want to reset your progress?";
        private const string TextUnsuccessfulOperation = "you do not have enough money";
        
        private readonly PaidResetService _paidResetService;
        
        private readonly ResetPopupView _view;
        
        private TextPopupPresenter _textPopupPresenter;

        private MainMenuPopupService _mainMenuPopupService;
        
        public ResetPopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            ResetPopupView view,
            PaidResetService paidResetService, 
            MainMenuPopupService mainMenuPopupService) : base(coroutinesPerformer)
        {
            _view = view;
            _paidResetService = paidResetService;
            _mainMenuPopupService = mainMenuPopupService;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();
            
            _view.SetTitle(Title);
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _view.Clicked -= OnClicked;
        }

        protected override void OnPreShow()
        {
            base.OnPreShow();

            _view.Clicked += OnClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();
            
            _view.Clicked -= OnClicked;
        }
        
        private void OnClicked()
        {
            if (_paidResetService.CanReset())
            {
                _paidResetService.Reset();    
                _mainMenuPopupService.ClosePopup(this);
            }
            else
            {
                _mainMenuPopupService.ClosePopup(this);
                _mainMenuPopupService.OpenTextPopup(TextUnsuccessfulOperation);
            }
        }
    }
}