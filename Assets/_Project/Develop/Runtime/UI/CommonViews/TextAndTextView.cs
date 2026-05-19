using _Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.CommonViews
{
    public class TextAndTextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _textFirst;
        [SerializeField] private TMP_Text _textSecond;

        public void SetTextFirst(string text) => _textFirst.text = text;
        public void SetTextSecond(string text) => _textSecond.text = text;
    }
}