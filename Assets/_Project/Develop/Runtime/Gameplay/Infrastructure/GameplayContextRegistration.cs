using _Project.Develop.Runtime.Gameplay.Core;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistration
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            container.RegisterAsSingle(CreateGeneratorLetters);
            container.RegisterAsSingle<IInput>(CreateUserKeyBoardInput);
            container.RegisterAsSingle(CreateTypingGameHandler);
            
            // Debug.Log("Process registration service on scene Gameplay");
        }

        private static GeneratorSymbols.GeneratorSymbols CreateGeneratorLetters(DIContainer c)
            => new GeneratorSymbols.GeneratorSymbols();
        
        private static UserKeyBoardInput CreateUserKeyBoardInput(DIContainer c)
            => new UserKeyBoardInput();

        private static TypingGameHandler CreateTypingGameHandler(DIContainer c)
            =>  new TypingGameHandler(c.Resolve<IInput>());
        
        private static GameCycle CreateHameCycle(DIContainer c)
            =>  new GameCycle(
                c.Resolve<TypingGameHandler>(),
                c.Resolve<GeneratorSymbols.GeneratorSymbols>(),
                c.Resolve<ConfigsProviderService>(),
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<SceneSwitcherService>());

        
        /*
        
        private static TypingGameHandler CreateTypingGameHandler(DIContainer c)
        {
            IInput input = c.Resolve<IInput>();
            
            return new TypingGameHandler();
        }
        
        */
    }
}