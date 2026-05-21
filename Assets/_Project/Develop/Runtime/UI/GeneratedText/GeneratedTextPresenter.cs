using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.GeneratorSymbols;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.GeneratedText
{
    public class GeneratedTextPresenter : IPresenter
    {
        private readonly GeneratorSymbols _generator;
        private readonly TextView _view;
        private readonly IInput _input;

        private string _currentText = string.Empty;
        private int _currentIndex;

        public GeneratedTextPresenter(TextView view, GeneratorSymbols generator, IInput input)
        {
            _view = view;
            _generator = generator;
            _input = input;
        }

        public void Initialize()
        {
            _generator.LetterGenerated += OnGeneratedLetter;
            _input.KeyPressed += OnKeyPressed;
        }

        public void Dispose()
        {
            _generator.LetterGenerated -= OnGeneratedLetter;
            _input.KeyPressed -= OnKeyPressed;
            ResetProgress();
        }
        
        private void OnKeyPressed(char inputChar)
        {
            if (string.IsNullOrEmpty(_currentText) || _currentIndex >= _currentText.Length)
                return;

            char expectedChar = _currentText[_currentIndex];

            if (inputChar == expectedChar)
            {
                _currentIndex++;

                SkipInvisibleCharacters();

                _view.UpdateHighlighting(_currentIndex);
            }
        }

        private void OnGeneratedLetter(IReadOnlyCollection<char> obj)
        {
            _currentText = string.Join("", obj);
            _view.SetText(_currentText);
            
            ResetProgress();
        }

        private void ResetProgress()
        {
            _currentIndex = 0;
            SkipInvisibleCharacters(); 
            _view.UpdateHighlighting(_currentIndex);
        }

        private void SkipInvisibleCharacters()
        {
            while (_currentIndex < _currentText.Length && _currentText[_currentIndex] == ' ')
                _currentIndex++;
        }
    }
}