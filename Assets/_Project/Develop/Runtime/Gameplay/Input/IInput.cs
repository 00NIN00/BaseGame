namespace _Project.Develop.Runtime.Gameplay.Input
{
    public interface IInput
    {
        string UserInput { get; }
        bool GetChar(out char c);
    }
}