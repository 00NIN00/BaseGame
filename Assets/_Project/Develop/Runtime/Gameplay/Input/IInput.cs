using System;
using System.Collections;

namespace _Project.Develop.Runtime.Gameplay.Input
{
    public interface IInput
    {
        event Action KeyPressedViewStats;
        event Action KeyPressedReset;
        
        string UserInputChars { get; }
        bool GetChar(out char c);
        
        IEnumerator Update();
    }
}