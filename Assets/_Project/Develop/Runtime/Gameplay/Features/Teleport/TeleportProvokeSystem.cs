using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportProvokeSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _inTeleportCooldown;
        private ReactiveEvent _teleportRequest;
        private ICompositeCondition _canTeleport;

        public void OnInit(Entity entity)
        {
            _inTeleportCooldown = entity.InTeleportCooldown;
            _teleportRequest = entity.TeleportRequest;
            _canTeleport = entity.CanTeleport;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inTeleportCooldown.Value)
                return;
            
            if (_canTeleport.Evaluate() == false)
                return;

            _teleportRequest.Invoke();
        }
    }
}