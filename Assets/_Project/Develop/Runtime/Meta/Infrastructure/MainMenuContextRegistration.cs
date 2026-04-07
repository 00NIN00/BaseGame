using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistration
    {
        public static void Process(DIContainer container)
        {
            CreateSelectGameModeService(container);
        }

        private static SelectGameModeService CreateSelectGameModeService(DIContainer c)
        {
            return new SelectGameModeService(c.Resolve<SceneSwitcherService>(), c.Resolve<ICoroutinesPerformer>());
        }
    }
}