using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.Input;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.View
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
            string synbols = "";
            
            foreach (char letter in letters)
            {
                synbols += letter;
                synbols += " ";
            }
            
            Debug.Log(synbols);
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