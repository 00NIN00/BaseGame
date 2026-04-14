using _Project.Develop.Runtime.Gameplay.Input;
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
            container.RegisterAsSingle(CreateTypingGameHandler);
            container.RegisterAsSingle(CreateHameCycle);
            container.RegisterAsSingle(CreateInitializationViewService);
            
            
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

        private static InitializationViewService CreateInitializationViewService(DIContainer c)
        {
            ResourcesAssetsLouder resourcesAssetsLouder = c.Resolve<ResourcesAssetsLouder>();
            
            ViewTypingGameHandler viewTypingGameHandlerPrefab = resourcesAssetsLouder
                .Load<ViewTypingGameHandler>("View");

            ViewTypingGameHandler viewTypingGameHandler = Object.Instantiate(viewTypingGameHandlerPrefab);
            
            
            InitializationViewService initializationViewService = new InitializationViewService(viewTypingGameHandler,
                c.Resolve<IInput>(),
                c.Resolve<GeneratorSymbols.GeneratorSymbols>(),
                c.Resolve<GameCycle>() );

            return initializationViewService;
        }
        
        /*
        
        private static TypingGameHandler CreateTypingGameHandler(DIContainer c)
        {
            IInput input = c.Resolve<IInput>();
            
            return new TypingGameHandler();
        }
        
        */
    }
}