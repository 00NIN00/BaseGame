using _Project.Develop.Runtime.Configs.Meta;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Gameplay.View;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class MainMenuInputHandler
    {
        private readonly DIContainer _container;
        private readonly ViewStats _viewStats;
        private readonly IInput _input;

        public MainMenuInputHandler(IInput input, DIContainer container, ViewStats viewStats)
        {
            _input = input;
            _container = container;
            _viewStats = viewStats;

            _input.KeyPressedReset += Reset;
            _input.KeyPressedViewStats += ViewStats;
        }

        private void Reset()
        {
            _container.Resolve<ResetProgressService>().ResetPlayerData();
        }

        private void ViewStats()
        {
            _viewStats.DebugStats();
        }
    }
}