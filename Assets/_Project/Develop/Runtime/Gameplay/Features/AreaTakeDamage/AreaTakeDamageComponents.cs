using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage
{
    public class AreaDamageAmount : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CanAreaDamage : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}