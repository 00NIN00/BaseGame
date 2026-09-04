using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Utilities.StateMachineCore
{
    public interface IState
    {
        IReadonlyEvent Entered { get; }
        IReadonlyEvent Exited { get; }
            
        void Enter();
        void Exit();
    }
}