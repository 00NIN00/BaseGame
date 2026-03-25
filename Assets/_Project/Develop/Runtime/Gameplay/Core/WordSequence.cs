using System.Collections.Generic;

namespace _Project.Develop.Runtime.Gameplay.Core
{
    public class WordSequence
    {
        private readonly Queue<char> _symbols;
    
        public int RemainingCount => _symbols.Count;

        public WordSequence(IEnumerable<char> symbols)
        {
            _symbols = new Queue<char>(symbols);
        }

        public bool TryMatch(char input)
        {
            if (_symbols.Count > 0 && _symbols.Peek() == input)
            {
                _symbols.Dequeue();
                return true;
            }
            return false;
        }
    }
}