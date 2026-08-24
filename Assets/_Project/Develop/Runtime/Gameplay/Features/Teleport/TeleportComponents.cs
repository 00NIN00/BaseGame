using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class TeleportEnergyCost : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    // Кулдаун телепортации
    public class TeleportCooldownInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class TeleportCooldownCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class InTeleportCooldown : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
    
    // Выбранная точка телепортации
    public class SelectedTeleportPoint : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class CanTeleport : IEntityComponent
    {
        public ICompositeCondition Value;
    }
    
    // События
    public class TeleportRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }
    
    public class TeleportPointSelectedEvent : IEntityComponent
    {
        public ReactiveEvent<Vector3> Value;
    }
    
    public class TeleportExecutedEvent : IEntityComponent
    {
        public ReactiveEvent<Vector3> Value;
    }
}