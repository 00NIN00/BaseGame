using _Project.Develop.Runtime.UI.Core;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace _Project.Develop.Runtime.UI.CommonViews
{
    public class IconTextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _image;
        
        public void SetText(string text) => _text.text = text;
        
        public void SetImage(Sprite sprite) => _image.sprite = sprite;
    }
}