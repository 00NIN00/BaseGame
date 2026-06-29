using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    public class SelfReleaseSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesLiveContext _entitiesLiveContext;
        
        private Entity _entity;
        private ICompositeCondition _mustSelfRelease;

        public SelfReleaseSystem(EntitiesLiveContext entitiesLiveContext)
        {
            _entitiesLiveContext = entitiesLiveContext;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _mustSelfRelease = entity.MustSelfRelease;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_mustSelfRelease.Evaluate())
                _entitiesLiveContext.Release(_entity);
        }
    }
}