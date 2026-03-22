using System;
using System.Collections;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Gameplay
{
    public class TypingGameHandler
    {
         // public event Action<char> OnCorrectLetter;
        public event Action LetterMismatched;//TODO:мб сделать кокой-нибудь класс gameRules который будет решать когда победа а когда поражение
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