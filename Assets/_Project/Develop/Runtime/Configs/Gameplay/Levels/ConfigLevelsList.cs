using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.Levels
{
    [CreateAssetMenu(fileName =  "ConfigLevels", menuName = "Configs/Gameplay/Levels/ConfigLevels", order = 0)]
    public class ConfigLevelsList : ScriptableObject
    {
        [SerializeField] private List<ConfigLevel> _levels;
        
        public IReadOnlyList<ConfigLevel> Levels => _levels;
        
        public ConfigLevel GetBy(int levelNumber)
        {
            int levelIndex = levelNumber - 1;
            return _levels[levelIndex];
        }
    }
}