using _Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.TextPopup
{
    public class TextPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _title;
        
        public void SetTitle(string title) => _title.text = title;
    }
}