using System;
using _Project.Develop.Runtime.Gameplay.Core;
using _Project.Develop.Runtime.Gameplay.Input;

namespace _Project.Develop.Runtime.Gameplay.View
{
    public class InitializationViewService : IDisposable
    {
        private readonly ViewTypingGameHandler _viewTypingGameHandler;
        private readonly IInput _input;
        private readonly GeneratorSymbols.GeneratorSymbols _generatorSymbols;
        private readonly GameCycle _gameCycle;

        public InitializationViewService(ViewTypingGameHandler viewTypingGameHandler, IInput input, GeneratorSymbols.GeneratorSymbols generatorSymbols, GameCycle gameCycle)
        {
            _viewTypingGameHandler = viewTypingGameHandler;
            _input = input;
            _generatorSymbols = generatorSymbols;
            _gameCycle = gameCycle;
        }

        public void Initialize()
        {
            // _viewTypingGameHandler.Initialize(_input);

            // _generatorSymbols.LetterGenerated += _viewTypingGameHandler.DebugLetters;
            // _gameCycle.Wined += _viewTypingGameHandler.Win;
            // _gameCycle.Defeated += _viewTypingGameHandler.Defeat;
        }
        
        public void Dispose()
        {
            // _generatorSymbols.LetterGenerated -= _viewTypingGameHandler.DebugLetters;
            // _gameCycle.Wined -= _viewTypingGameHandler.Win;
            // _gameCycle.Defeated -= _viewTypingGameHandler.Defeat;
        }
    }
}