using System.Collections.Generic;
using System;

using Random = UnityEngine.Random;

namespace _Project.Develop.Runtime.Gameplay
{
    public class GeneratorSymbols
    {
        public event Action<IReadOnlyCollection<char>> LetterGenerated;
        
        public IReadOnlyCollection<char> Generate(int count, params char[] chars)
        {
            Queue<char> queue = new Queue<char>();
            
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(chars[Random.Range(0, chars.Length)]);
            }
            
            LetterGenerated?.Invoke(queue);
            
            return queue;
        }
    }
}