namespace _Project.Develop.Runtime.Gameplay
{
    public interface IInput
    {
        string userInput { get; }
        bool GetChar(out char c);
    }
}