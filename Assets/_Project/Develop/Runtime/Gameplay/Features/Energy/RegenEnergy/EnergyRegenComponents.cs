using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergy
{
    public class EnergyRegenPercentage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class EnergyRegenIntervalInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
   
    public class EnergyRegenIntervalCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class InEnergyRegenCooldown : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class CanRegenEnergy : IEntityComponent//TODO: нужно ли разбить этот класс на несколько? типа компоненты энергии, компоненты восстановления энергии
    {
        public ICompositeCondition Value;
    }
    public class RegenEnergyRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class RegenEnergyEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }
}