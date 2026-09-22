using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class TeleportState : State, IUpdatableState
    {
        private readonly ReactiveEvent _teleportRequest;

        public TeleportState(Entity entity)
        {
            _teleportRequest = entity.TeleportRequest;
        }

        public override void Enter()
        {
            base.Enter();
            _teleportRequest.Invoke();
        }

        public void Update(float deltaTime)
        {
        }
    }
}