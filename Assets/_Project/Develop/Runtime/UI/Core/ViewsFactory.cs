using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.UI.Core
{
    public class ViewsFactory
    {
        private readonly ResourcesAssetsLouder _resourcesAssetsLouder;

        private readonly Dictionary<string, string> _viewIDToResourcePath = new Dictionary<string, string>()
        {
            {ViewIDs.CurrentView, "UI/Wallet/CurrencyView"},
            {ViewIDs.MainMenuScreen, "UI/MainMenu/MainMenuScreenView"},
        };
        
        public ViewsFactory(ResourcesAssetsLouder resourcesAssetsLouder)
        {
            _resourcesAssetsLouder = resourcesAssetsLouder;
        }

        public TView Create<TView>(string viewId, Transform parent = null) where TView : MonoBehaviour,  IView
        {
            if (_viewIDToResourcePath.TryGetValue(viewId, out string resourcePath) == false)
                throw new ArgumentException($"You did not set resource path {typeof(TView)}, searched id; {viewId}");

            GameObject prefab = _resourcesAssetsLouder.Load<GameObject>(resourcePath);
            GameObject instance = Object.Instantiate(prefab, parent);
            TView view = instance.GetComponent<TView>();

            if (view == null)
                throw new InvalidOperationException($"Not found {typeof(TView)}, component on view instance");
            
            return view;
        }

        public void Release<TView>(TView view) where TView : MonoBehaviour, IView
        {
            Object.Destroy(view.gameObject);
        }
    }
}