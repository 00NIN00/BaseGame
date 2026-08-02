using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    // Параметры способности 
    //TODO:добавить условия лоя телепортации
    public class TeleportRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value; // N - радиус телепортации
    }
    
    public class DamageOnTeleport : IEntityComponent
    {
        public ReactiveVariable<float> Value; // D - урон при телепорте
    }
    
    public class DamageRadiusOnTeleport : IEntityComponent
    {
        public ReactiveVariable<float> Value; // M - радиус урона после телепорта
    }
    
    public class TeleportEnergyCost : IEntityComponent
    {
        public ReactiveVariable<float> Value; // X - стоимость энергии
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