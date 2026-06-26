using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    public class CurrentHealth : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class MaxHealth : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class IsDead : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}