using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.UI.LevelsMenuPopup;
using _Project.Develop.Runtime.UI.TextPopup;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.Core
{
    public abstract class PopupService : IDisposable
    {
         protected readonly ViewsFactory ViewsFactory;
         private readonly ProjectPresentsFactory _presentsFactory;

         private readonly Dictionary<PopupPresenterBase, PopupInfo> _presenterToInfo = new();
         
         protected PopupService(
             ViewsFactory viewsFactory,
             ProjectPresentsFactory presentsFactory)
         {
             ViewsFactory = viewsFactory;
             _presentsFactory = presentsFactory;
         }

         protected abstract Transform PopupLayer { get; }
         
         // public TestPopupPresenter OpenLevelsMenuPopup(Action closedCallback = null)
         // {
         //     TestPopupView view = ViewsFactory.Create<TestPopupView>(ViewIDs.TestPopup,  PopupLayer);
         //     
         //     TestPopupPresenter popup = _presentsFactory.CreateTestPopupPresenter(view);
         //     
         //     OnPopupCreated(popup, view, closedCallback);
         //     return popup;
         // }

         public LevelsMenuPopupPresenter OpenLevelsMenuPopup()
         {
             LevelsMenuPopupView view = ViewsFactory.Create<LevelsMenuPopupView>(ViewIDs.LevelsMenuPopup, PopupLayer);
             
             LevelsMenuPopupPresenter popup = _presentsFactory.CreateLevelsMenuPopupPresenter(view);
             
             OnPopupCreated(popup, view);
             
             return popup;
         }
         
         public TextPopupPresenter OpenTextPopup(string text)
         {
             TextPopupView view = ViewsFactory.Create<TextPopupView>(ViewIDs.TextPopupView, PopupLayer);
             
             TextPopupPresenter popup = _presentsFactory.CreateTextPopupPresenter(view);
             
             OnPopupCreated(popup, view);
             
             popup.SetText(text);
             
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
             ViewsFactory.Release(_presenterToInfo[popup].View);
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