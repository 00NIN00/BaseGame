using System.Collections;
using System;

namespace _Project.Develop.Runtime.Gameplay.Input
{
    public class UserKeyBoardInput : IInput
    {
        public event Action KeyPressedViewStats;
        public event Action KeyPressedReset;

        public string UserInputChars => UnityEngine.Input.inputString;

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
                if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.V))
                    KeyPressedViewStats?.Invoke();

                if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.R))
                    KeyPressedReset?.Invoke();
                
                yield return null;
            }
        }
    }
}