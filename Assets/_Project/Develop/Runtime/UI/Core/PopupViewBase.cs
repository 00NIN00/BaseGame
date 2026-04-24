using System;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.Core
{
    public abstract class PopupViewBase : MonoBehaviour, IShowableView
    {
        public event Action CloseRequest;
        
        [SerializeField] private CanvasGroup _mainGroup;

        private void Awake()
        {
            _mainGroup.alpha = 0;
        }
        
        public void OnCloseButtonClicked() => CloseRequest?.Invoke();
        
        public void Show()
        {
            OnPreShow();
            
            //animation
            _mainGroup.alpha = 1;
            
            OnPostShow();
        }

        protected virtual void OnPreShow()
        { }
        
        protected virtual void OnPostShow()
        { }
        
        public void Hide()
        {
            OnPreHide();
            
            //animation
            _mainGroup.alpha = 0;

            OnPostHide(); 
        }
        
        protected virtual void OnPreHide()
        { }
        
        protected virtual void OnPostHide()
        { }
    }
}