using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage
{
    public class AreaDamageRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class AreaDamageMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class AreaDamageContactsBuffer : IEntityComponent
    {
        public Buffer<Collider> Value;
    }

    public class AreaDamageTargetsBuffer : IEntityComponent
    {
        public Buffer<Entity> Value;
    }
}