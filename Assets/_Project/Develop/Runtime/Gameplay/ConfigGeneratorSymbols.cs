using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]//TODO:dsa
    public class ConfigGeneratorSymbols : ScriptableObject
    {
        [field:SerializeField] public int CountSymbols { get; private set; }
    }
}