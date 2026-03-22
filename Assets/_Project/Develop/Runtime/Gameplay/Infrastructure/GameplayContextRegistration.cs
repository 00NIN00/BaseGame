using _Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistration
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            container.RegisterAsSingle(CreateGeneratorLetters);
            container.RegisterAsSingle<IInput>(CreateUserKeyBoardInput);
            
            Debug.Log("Process registration service on scene Gameplay");
        }

        private static GeneratorSymbols CreateGeneratorLetters(DIContainer c)
            => new GeneratorSymbols();
        
        private static UserKeyBoardInput CreateUserKeyBoardInput(DIContainer c)
            => new UserKeyBoardInput();

        /*
        
        private static TypingGameHandler CreateTypingGameHandler(DIContainer c)
        {
            IInput input = c.Resolve<IInput>();
            
            return new TypingGameHandler();
        }
        
        */
        
        private static ListNumbers CreateListNumbers(DIContainer c) 
            => new ListNumbers();
        private static ListLetters CreateListLetters(DIContainer c) 
            => new ListLetters();
    }
}