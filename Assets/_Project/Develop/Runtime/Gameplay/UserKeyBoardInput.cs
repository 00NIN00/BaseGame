using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class UserKeyBoardInput : IInput
    {
        public string userInput => Input.inputString;

        public bool GetChar(out char c)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                c = '\0';
                return false;
            }
            
            c = userInput[0];
            return true;
        }
    }
}