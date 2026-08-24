using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergy
{
    public class CanAddEnergy : IEntityComponent
    {
        public ICompositeCondition Value;
    }
   
    public class AddEnergyRequest : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }

    public class AddEnergyEvent : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }
}