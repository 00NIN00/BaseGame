using _Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.CommonViews
{
    public class TextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;

        [Header("Настройки цветов")]
        [SerializeField] private Color32 _typedColor = new Color32(0, 255, 0, 255);
        [SerializeField] private Color32 _currentColor = new Color32(255, 215, 0, 255);
        [SerializeField] private Color32 _untypedColor = new Color32(180, 180, 180, 255);

        public void SetText(string text) => _text.text = text;
        
        public void UpdateHighlighting(int currentIndex)
        {
            _text.ForceMeshUpdate();
            TMP_TextInfo textInfo = _text.textInfo;

            for (int i = 0; i < textInfo.characterCount; i++)
            {
                TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
                
                if (!charInfo.isVisible) continue;

                int materialIndex = charInfo.materialReferenceIndex;
                int vertexIndex = charInfo.vertexIndex;
                Color32[] vertexColors = textInfo.meshInfo[materialIndex].colors32;

                Color32 targetColor = _untypedColor;
                
                if (i < currentIndex)
                    targetColor = _typedColor;
                else if (i == currentIndex)
                    targetColor = _currentColor;
                
                vertexColors[vertexIndex + 0] = targetColor;
                vertexColors[vertexIndex + 1] = targetColor;
                vertexColors[vertexIndex + 2] = targetColor;
                vertexColors[vertexIndex + 3] = targetColor;
            }

            _text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
        }
    }
}