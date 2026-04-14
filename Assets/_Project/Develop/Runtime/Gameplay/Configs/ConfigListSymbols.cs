using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "ConfigListSymbols", menuName = "Configs/ListSymbols", order = 0)]
    public class ConfigListSymbols : ScriptableObject
    {
        [field: SerializeField] public string Symbols { get; private set; }
    }
}