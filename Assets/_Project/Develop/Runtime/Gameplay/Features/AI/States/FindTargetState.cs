using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class FindTargetState : State, IUpdatableState
    {
        private ITargetSelector _targetSelector;
        private EntitiesLiveContext _entitiesLiveContext;
        
        private ReactiveVariable<Entity> _currentTarget;
        
        public FindTargetState(Entity entity, ITargetSelector targetSelector, EntitiesLiveContext entitiesLiveContext)
        {
            _currentTarget = entity.CurrentTarget;
            
            _targetSelector = targetSelector;
            _entitiesLiveContext = entitiesLiveContext;
        }

        public void Update(float deltaTime)
        {
            _currentTarget.Value = _targetSelector.SelectTargetFrom(_entitiesLiveContext.Entities);
        }
    }
}