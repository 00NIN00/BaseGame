using System.Collections;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.LoadingScreen;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("GameEntryPoint Awake");
            
            SetupAppSettings();
            
            Debug.Log("Process registration service all project");
            
            DIContainer projectContainer = new DIContainer();
            
            ProjectContextRegistration.Process(projectContainer);

            projectContainer.Initialize();
            
            projectContainer.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(projectContainer));
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();
            
            loadingScreen.Show();
            
            Debug.Log("Start initialization service");

            yield return container.Resolve<ConfigsProviderService>().LoadAsync();

            bool isPlayerDataSaveExists = false;
            
            yield return playerDataProvider.Exists(result => isPlayerDataSaveExists = result);
            
            if (isPlayerDataSaveExists)
                yield return playerDataProvider.Load();
            else
                playerDataProvider.Reset();

            container.Resolve<ICoroutinesPerformer>().StartPerform(container.Resolve<IInput>().Update());
            
            yield return new WaitForSeconds(1f);
            
            Debug.Log("End initialization service");
            
            loadingScreen.Hide();

            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu);
        }
    }
}