using System.Collections;
using System;
using UnityEngine.InputSystem;

namespace _Project.Develop.Runtime.Gameplay.Input
{
    public class UserKeyBoardInput : IInput, IDisposable
    {
        public event Action KeyPressedViewStats;
        public event Action KeyPressedReset;
        public event Action<char> KeyPressed;

        public string UserInputChars => UnityEngine.Input.inputString;

        public UserKeyBoardInput()
        {
            Keyboard.current.onTextInput += OnTextInput;
        }
        
        public bool GetChar(out char c)
        {
            if (string.IsNullOrEmpty(UserInputChars))
            {
                c = '\0';
                return false;
            }

            c = UserInputChars[0];
            
            return true;
        }

        public IEnumerator Update()
        {
            while (true)
            {
                if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.V))
                    KeyPressedViewStats?.Invoke();
                
                if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.R))
                    KeyPressedReset?.Invoke();
                
                yield return null;
            }
            // ReSharper disable once IteratorNeverReturns
        }
        
        private void OnTextInput(char character) => KeyPressed?.Invoke(character);
        
        public void Dispose()
        {
            Keyboard.current.onTextInput -= OnTextInput;
        }
    }
}