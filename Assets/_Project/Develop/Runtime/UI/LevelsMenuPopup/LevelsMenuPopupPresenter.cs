using System.Collections.Generic;
using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.LevelsMenuPopup
{
    public class LevelsMenuPopupPresenter : PopupPresenterBase
    {
        private const string TitleName = "Levels";
        
        private readonly ConfigsProviderService _configsProviderService;
        private readonly ProjectPresentsFactory _presentsFactory;
        private readonly ViewsFactory _viewsFactory;
        
        private readonly LevelsMenuPopupView _view;
        
        private readonly List<LevelTitlePresenter> _levelTitlePresenters = new();
        public LevelsMenuPopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            ConfigsProviderService configsProviderService,
            ProjectPresentsFactory presentsFactory,
            ViewsFactory viewsFactory,
            LevelsMenuPopupView view) : base(coroutinesPerformer)
        {
            _configsProviderService = configsProviderService;
            _presentsFactory = presentsFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();
            
            _view.SetTitle(TitleName);
            
            ConfigLevelsList configLevelsList = _configsProviderService.GetConfig<ConfigLevelsList>();

            for (int i = 0; i < configLevelsList.Levels.Count; i++)
            {
                LevelTitleView levelTitleView = _viewsFactory.Create<LevelTitleView>(ViewIDs.LevelTile);
                
                _view.LevelTilesListView.Add(levelTitleView);
                
                Debug.Log(i+1);
                LevelTitlePresenter levelTitlePresenter = _presentsFactory.CreateLevelTitlePresenter(levelTitleView, i + 1, configLevelsList.GetBy(i+1));
                
                levelTitlePresenter.Initialize();
                
                _levelTitlePresenters.Add(levelTitlePresenter);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (LevelTitlePresenter levelTitlePresenter in _levelTitlePresenters)
            {
                _view.LevelTilesListView.Remove(levelTitlePresenter.View);
                _viewsFactory.Release(levelTitlePresenter.View);
                levelTitlePresenter.Dispose();
            }
            
            _levelTitlePresenters.Clear();
        }
        
        protected override void OnPreShow()
        {
            base.OnPreShow();

            foreach (LevelTitlePresenter levelTitlePresenter in _levelTitlePresenters)
                levelTitlePresenter.Subscribe();
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();
            
            foreach (LevelTitlePresenter levelTitlePresenter in _levelTitlePresenters)
                levelTitlePresenter.Unsubscribe();
        }
    }
}