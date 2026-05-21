using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;

namespace _Project.Develop.Runtime.UI.TextPopup
{
    public class TextPopupPresenter : PopupPresenterBase
    {
        private readonly TextPopupView _view;
        
        public TextPopupPresenter(ICoroutinesPerformer coroutinesPerformer, TextPopupView view) : base(coroutinesPerformer)
        {
            _view = view;
        }

        protected override PopupViewBase PopupView => _view;

        public void SetText(string text) => _view.SetTitle(text);
    }
}