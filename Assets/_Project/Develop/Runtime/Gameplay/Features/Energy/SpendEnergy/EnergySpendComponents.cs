using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergy
{
    public class CanSpendEnergy : IEntityComponent
    {
        public ICompositeCondition<float> Value;
    }
    
    public class SpendEnergyRequest : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }

    public class SpendEnergyEvent : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }
}