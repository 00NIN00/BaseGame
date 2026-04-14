using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.Input;

namespace _Project.Develop.Runtime.Gameplay.Core
{
    public class TypingGameHandler
    {
         // public event Action<char> OnCorrectLetter;
        public event Action LetterMismatched;
        public event Action LettersSequenceFinished;
        
        private IInput _input;
        
        private WordSequence _sequence;

        public TypingGameHandler(IInput input)
        {
            _input = input;
        }
        
        
        public IEnumerator GameLoopCoroutine(IEnumerable<char> symbols)
        {
            _sequence = new WordSequence(symbols);
            
            while (_sequence.RemainingCount > 0)
            {
                if (_input.GetChar(out char symbol))
                {
                    if (_sequence.TryMatch(symbol))
                    {
                        // OnCorrectLetter?.Invoke(symbol);
                        if (_sequence.RemainingCount == 0)
                        {
                            LettersSequenceFinished?.Invoke();
                            yield break;
                        }
                    }
                    else
                    {
                        LetterMismatched?.Invoke();
                        yield break;
                    }
                }

                yield return null;
            }
        }
    }
}