using _Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "ConfigBuyReset", menuName = "Configs/ConfigBuyReset", order = 0)]
    public class ConfigBuyReset : ScriptableObject
    {
        [field:SerializeField] public CurrencyType CurrencyType {get; private set;}
        
        [field: SerializeField] public int Count {get; private set;}
    }
}