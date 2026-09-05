namespace _Project.Develop.Runtime.Gameplay.Features.AI
{
    public class StateMachineBrain : IBrain
    {
        private AIStateMachine _stateMachine;

        private bool _isEnable;
        
        public StateMachineBrain(AIStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Disable()
        {
            _stateMachine.Exit();
            _isEnable = false;
        }
        
        public void Dispose()
        {
            _stateMachine.Dispose();
            _isEnable = false;
        }

        public void Enable()
        {
            _stateMachine.Enter();
            _isEnable = true;
        }

        public void Update(float deltaTime)
        {
            if (_isEnable == false)
                return;
            
            _stateMachine.Update(deltaTime);
        }
    }
}