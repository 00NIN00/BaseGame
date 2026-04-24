using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.Core
{
    public abstract class PopupService : IDisposable
    {
         protected readonly ViewsFactory ViewFactory;
         private readonly ProjectPresentsFactory _presentsFactory;

         private readonly Dictionary<PopupPresenterBase, PopupInfo> _presenterToInfo = new();
         
         protected PopupService(
             ViewsFactory viewFactory,
             ProjectPresentsFactory presentsFactory)
         {
             ViewFactory = viewFactory;
             _presentsFactory = presentsFactory;
         }

         protected abstract Transform PopupLayer { get; }
         
         public TestPopupPresenter OpenTestPopup(Action closedCallback = null)
         {
             TestPopupView view = ViewFactory.Create<TestPopupView>(ViewIDs.TestPopup,  PopupLayer);
             
             TestPopupPresenter popup = _presentsFactory.CreateTestPopupPresenter(view);
             
             OnPopupCreated(popup, view, closedCallback);
             return popup;
         }

         public void ClosePopup(PopupPresenterBase popup)
         {
             popup.CloseRequest -= ClosePopup;
             
             popup.Hide(() =>
             {
                 _presenterToInfo[popup].CloseCallback?.Invoke();
                 
                 DisposeFor(popup);
                 _presenterToInfo.Remove(popup);
             });
         }

         public void Dispose()
         {
             foreach (PopupPresenterBase popup in _presenterToInfo.Keys)
             {
                 popup.CloseRequest -= ClosePopup;
                 DisposeFor(popup);
             }    
             
             _presenterToInfo.Clear();
         }
         
         protected void OnPopupCreated(
             PopupPresenterBase popup,
             PopupViewBase view,
             Action closedCallback = null)
         {
             PopupInfo popupInfo = new  PopupInfo(view, closedCallback);
             _presenterToInfo.Add(popup, popupInfo);
             
             popup.Initialize();
             popup.Show();

             popup.CloseRequest += ClosePopup;
         }
         
         private void DisposeFor(PopupPresenterBase popup)
         {
             popup.Dispose();
             ViewFactory.Release(_presenterToInfo[popup].View);
         }

         private class PopupInfo
         {
             public PopupInfo(PopupViewBase view, Action closeCallback)
             {
                 View = view;
                 CloseCallback = closeCallback;
             }

             public PopupViewBase View { get; }
             public Action CloseCallback { get; }
         }
    }
}