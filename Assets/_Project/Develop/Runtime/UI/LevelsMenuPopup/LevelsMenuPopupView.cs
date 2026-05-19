using _Project.Develop.Runtime.UI.Core;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

namespace _Project.Develop.Runtime.UI.LevelsMenuPopup
{
    public class LevelsMenuPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private LevelTilesListView _levelTilesListView;
        
        public LevelTilesListView LevelTilesListView => _levelTilesListView;
        
        public void SetTitle(string title) => _title.text = title;

        protected override void ModifyShowAnimation(Sequence animation)
        {
            base.ModifyShowAnimation(animation);

            foreach (LevelTitleView levelTitleView in _levelTilesListView.Elements)
            {
                animation.Append(levelTitleView.Show());
                animation.AppendInterval(0.1f);
            }
        }
    }
}