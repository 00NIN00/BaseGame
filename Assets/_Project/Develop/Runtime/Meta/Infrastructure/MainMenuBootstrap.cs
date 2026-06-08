using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using System.Collections;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        
        private PlayerDataProvider _playerDataProvider;
        
        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistration.Process(container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Initializing Menu Scene");

            _playerDataProvider = _container.Resolve<PlayerDataProvider>();
            
            yield break;
        }


        public override void Run()
        {
            Debug.Log("Start Menu Scene");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _container.Resolve<ICoroutinesPerformer>().StartPerform(_playerDataProvider.Save());
                
                Debug.Log("Saved Data");
            }
            
            // if (Input.GetKeyDown(KeyCode.L))
            // {
            //     _container.Resolve<ICoroutinesPerformer>().StartPerform(LoadPlayerData());
            //     Debug.Log("Load Data");
            // }
        }

        private void OnDestroy()
        {
            //_inputHandler.Dispose();
        }
    }
}