using System.Collections.Generic;

namespace _Project.Develop.Runtime.Gameplay
{
    public interface IListSymbols
    {
        List<char> Symbols { get; }
    }
    
    public class ListNumbers : IListSymbols
    {
        public List<char> Symbols => new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
    }
    
    public class ListLetters : IListSymbols
    {
        public List<char> Symbols => new List<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
    }
}