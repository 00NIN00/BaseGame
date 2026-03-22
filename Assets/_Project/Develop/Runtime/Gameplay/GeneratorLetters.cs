using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class GeneratorLetters
    {
        public IReadOnlyCollection<char> Generate(int count, params char[] chars)
        {
            Queue<char> queue = new Queue<char>();
            
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(chars[Random.Range(0, chars.Length)]);
            }
            
            return queue;
        }
    }
}