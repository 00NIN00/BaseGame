using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    public class SelfReleaseSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesLiveContext _entitiesLiveContext;
        
        private Entity _entity;
        private ReactiveVariable<bool> _isDead;

        public SelfReleaseSystem(EntitiesLiveContext entitiesLiveContext)
        {
            _entitiesLiveContext = entitiesLiveContext;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _isDead = entity.IsDead;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDead.Value)
                _entitiesLiveContext.Release(_entity);
        }
    }
}