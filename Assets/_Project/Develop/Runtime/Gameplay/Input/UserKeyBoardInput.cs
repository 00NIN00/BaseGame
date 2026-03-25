namespace _Project.Develop.Runtime.Gameplay.Input
{
    public class UserKeyBoardInput : IInput
    {
        public string UserInput => UnityEngine.Input.inputString;

        public bool GetChar(out char c)
        {
            if (string.IsNullOrEmpty(UserInput))
            {
                c = '\0';
                return false;
            }
            
            c = UserInput[0];
            return true;
        }
    }
}