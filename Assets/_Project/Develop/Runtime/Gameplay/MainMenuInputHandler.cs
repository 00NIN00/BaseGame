using _Project.Develop.Runtime.Configs.Meta;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Gameplay.View;
using _Project.Develop.Runtime.Infrastructure.DI;

namespace _Project.Develop.Runtime.Gameplay
{
    public class MainMenuInputHandler
    {
        private readonly ResetProgressService _resetProgressService;
        private readonly ViewStats _viewStats;
        private readonly IInput _input;

        public MainMenuInputHandler(IInput input, ResetProgressService resetProgressService, ViewStats viewStats)
        {
            _input = input;
            _resetProgressService = resetProgressService;
            _viewStats = viewStats;
        }

        public void Subscribe()
        {
            _input.KeyPressedReset += Reset;
            _input.KeyPressedViewStats += ViewStats;
        }
        
        public void UnSubscribe()
        {
            _input.KeyPressedReset -= Reset;
            _input.KeyPressedViewStats -= ViewStats;
        }

        private void Reset()
        {
            _resetProgressService.ResetPlayerData();
        }

        private void ViewStats()
        {
            _viewStats.DebugStats();
        }
    }
}