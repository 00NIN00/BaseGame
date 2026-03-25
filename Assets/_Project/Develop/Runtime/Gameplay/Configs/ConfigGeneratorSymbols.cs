using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "ConfigGeneratorSymbols", menuName = "Configs/GeneratorSymbols", order = 0)]
    public class ConfigGeneratorSymbols : ScriptableObject
    {
        [field:SerializeField] public int CountSymbols { get; private set; }
    }
}