using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

namespace _Project.Develop.Runtime.Gameplay
{
    public class Test : MonoBehaviour
    {
        private TypingGameHandler _gameHandler;
        
        private IListSymbols _allList;
        private GeneratorLetters _generator;
        private IInput _input;

        private void Awake()
        {
            _allList = new ListNumbers();
            _generator = new GeneratorLetters();
            _input = new UserKeyBoardInput();
            
            var letters = _generator.Generate(3, _allList.Symbols.ToArray());
            
            _gameHandler = new TypingGameHandler(letters, _input);

            StartCoroutine(_gameHandler.GameLoopCoroutine());

            foreach (char letter in letters)
            {
                Debug.Log(letter);
            }
            
            _gameHandler.OnCorrectLetter += (c) => Debug.Log(c);
            _gameHandler.OnWrongLetter += () => Debug.Log("NO");
            _gameHandler.OnWin += () => Debug.Log("Win");

        }
    }

    public class TypingGameHandler
    {
        public event Action<char> OnCorrectLetter;
        public event Action OnWrongLetter;
        public event Action OnWin;
        
        private IInput _input;
        
        private WordSequence _sequence;

        public TypingGameHandler(IEnumerable<char> symbols, IInput input)
        {
            _sequence = new WordSequence(symbols);
            _input = input;
        }
        
        
        public IEnumerator GameLoopCoroutine()
        {
            while (_sequence.RemainingCount > 0)
            {
                if (_input.GetChar(out char symbol))
                {
                    if (_sequence.TryMatch(symbol))
                    {
                        OnCorrectLetter?.Invoke(symbol);

                        if (_sequence.RemainingCount == 0)
                        {
                            OnWin?.Invoke();
                            yield break;
                        }
                    }
                    else
                    {
                        OnWrongLetter?.Invoke();
                    }
                }

                yield return null;
            }
        }
    }

}
