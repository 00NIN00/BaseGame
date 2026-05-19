using System;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.UI.OutcomesCounter
{
    public class OutcomesPresenter : IPresenter
    {
        private readonly IReadOnlyReactiveValue<int> _outcomes;
        private readonly OutcomesType _currentType;
        //private readonly ConfigCurrencyIcons _configCurrencyIcons;

        private readonly TextAndTextView _view;
        
        private IDisposable _disposable;

        public OutcomesPresenter(IReadOnlyReactiveValue<int> outcomes,
            OutcomesType currentType,
            TextAndTextView view)
        {
            _outcomes = outcomes;
            _currentType = currentType;
            _view = view;
        }
        
        public TextAndTextView View => _view;

        public void Initialize()
        {
            UpdateValue(_outcomes.Value);
            _view.SetTextFirst(_currentType.ToString());

            _disposable = _outcomes.Subscribe(OnOutcomesChanged);
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
        
        private void OnOutcomesChanged(int arg1, int newValue)
            => UpdateValue(newValue);
        
        private void UpdateValue(int value) 
            => _view.SetTextSecond(value.ToString());
    }
}