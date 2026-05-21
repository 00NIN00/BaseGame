using System;
using _Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.ResetPopup
{
    public class ResetPopupView : PopupViewBase
    {
        public event Action Clicked;
        
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _resetButton;
        
        public void SetTitle(string title) => _title.text = title;
        
        private void OnEnable()
        {
            _resetButton.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _resetButton.onClick.RemoveListener(OnClick);
        }
        
        private void OnClick() => Clicked?.Invoke();
    }
}