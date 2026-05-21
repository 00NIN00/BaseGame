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
        
        private readonly PaidResetService _paidResetService;
        
        private readonly ResetPopupView _view;
        
        private TextPopupPresenter _textPopupPresenter;
        // private TextPopupView _textPopupView;
        
        public ResetPopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            ResetPopupView view,
            PaidResetService paidResetService) : base(coroutinesPerformer)
        {
            _view = view;
            _paidResetService = paidResetService;
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
                _view.OnCloseButtonClicked();//TODO: сделать нормально через closeRequest
            }
            else
            {
                //_mainMenuPopupService.OpenTextPopup("Not");
                //TODO:почему мы его сдесь делаем он даже не дочерний, он не должен зависить, он самостоятельный
            }
        }
    }
}