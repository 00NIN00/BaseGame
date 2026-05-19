using System;
using _Project.Develop.Runtime.Gameplay;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Meta.Features.LevelsProgression;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.LevelsMenuPopup
{
    public class LevelTitlePresenter : ISubscribedPresenter
    {
        private readonly LevelsProgressionService _levelsService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly SceneSwitcherService _sceneSwitcherService;

        private readonly int _levelNumber;
        private readonly LevelTitleView _view;

        public LevelTitlePresenter(
            LevelsProgressionService levelsService,
            ICoroutinesPerformer coroutinesPerformer,
            SceneSwitcherService sceneSwitcherService,
            int levelNumber,
            LevelTitleView view)
        {
            _levelsService = levelsService;
            _coroutinesPerformer = coroutinesPerformer;
            _sceneSwitcherService = sceneSwitcherService;
            _levelNumber = levelNumber;
            _view = view;
        }

        public LevelTitleView View => _view;
        
        public void Initialize()
        {
            _view.SetLevel(_levelNumber.ToString());

            if (_levelsService.CanPlay(_levelNumber))
            {
                if (_levelsService.IsLevelCompleted(_levelNumber))
                    _view.SetComplete();
                else
                    _view.SetActive();
            }
            else
            {
                _view.SetBlock();
            }
        }

        public void Dispose()
        {
            _view.Clicked -= OnViewClicked;
        }
        
        public void Subscribe()
        {
            _view.Clicked += OnViewClicked;
        }

        public void Unsubscribe()
        {
            _view.Clicked -= OnViewClicked;
        }
        
        private void OnViewClicked()
        {
            if (_levelsService.CanPlay(_levelNumber) == false)
            {
                Debug.Log("Уровень заблокирован, пройдите предыдущий");
                return;
            }

            _coroutinesPerformer
                .StartPerform(
                    _sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(GameMode.Letters)));
        }
    }
}