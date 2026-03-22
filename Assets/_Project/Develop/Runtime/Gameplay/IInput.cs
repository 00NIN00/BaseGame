using System;

namespace _Project.Develop.Runtime.Gameplay
{
    public interface IInput
    {
        //event Action<char> Writed; 
        
        string userInput { get; }
        bool GetChar(out char c);
    }
}