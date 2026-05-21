using System;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action OpenLevelsMenuButtonClicked;
        public event Action ResetButtonClicked;
        
        [field:SerializeField] public IconTextListView WalletView { get; private set; }
        [field:SerializeField] public TextAndTextListView OutcomesCounter { get; private set; }
        [SerializeField] private Button _openLevelsMenuButton;
        [SerializeField] private Button _resetButton;

        private void OnEnable()
        {
            _openLevelsMenuButton.onClick.AddListener(OnOpenLevelsMenuButtonClicked);
            _resetButton.onClick.AddListener(OnResetButtonClicked);
        }

        private void OnDisable()
        {
            _openLevelsMenuButton.onClick.RemoveListener(OnOpenLevelsMenuButtonClicked);
            _resetButton.onClick.RemoveListener(OnResetButtonClicked);
        }

        private void OnOpenLevelsMenuButtonClicked() => OpenLevelsMenuButtonClicked?.Invoke();
        private void OnResetButtonClicked() =>  ResetButtonClicked?.Invoke();
    }
}