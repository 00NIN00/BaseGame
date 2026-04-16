using System;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Gameplay.View;
using _Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class MainMenuInputHandler : IDisposable
    {
        private readonly PaidResetService _paidResetService;
        private readonly ViewStats _viewStats;
        private readonly IInput _input;

        public MainMenuInputHandler(IInput input, PaidResetService resetProgressService, ViewStats viewStats)
        {
            _input = input;
            _paidResetService = resetProgressService;
            _viewStats = viewStats;
        }

        public void Subscribe()
        {
            _input.KeyPressedReset += Reset;
            _input.KeyPressedViewStats += ViewStats;
        }

        private void Reset()
        {
            if (_paidResetService.CanReset())
                _paidResetService.Reset();
            else
                Debug.Log("it is not possible to reset progress");
        }

        private void ViewStats()
        {
            _viewStats.DebugStats();
        }

        public void Dispose()
        {
            _input.KeyPressedReset -= Reset;
            _input.KeyPressedViewStats -= ViewStats;
        }
    }
}