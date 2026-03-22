using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class ViewTypingGameHandler : MonoBehaviour
    {
        private IInput _input;
        
        public void Initialize(IInput input)
        {
            _input = input;
        }

        private void Update()
        {
            if (_input == null) 
                return;
            
            if (_input.GetChar(out var c))
            {
                DebugLetter(c);
            }
        }

        public void DebugLetters(IEnumerable<char> letters)
        {
            foreach (char letter in letters)
            {
                DebugLetter(letter);
            }
        }

        private void DebugLetter(char letter)
        {
            Debug.Log(letter);
        }
        
        public void Win()
        {
            Debug.Log("Win");
        }

        public void Defeat()
        {
            Debug.Log("Defeat");
        }
    }
}