using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Gameplay;
using System.Collections;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Wallet;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private SelectGameModeService _selectGameModeService;
        
        private PlayerDataProvider _playerDataProvider;
        private MainMenuInputHandler _inputHandler;
        
        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistration.Process(container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Initializing Menu Scene");

            _selectGameModeService = _container.Resolve<SelectGameModeService>();

            _playerDataProvider = _container.Resolve<PlayerDataProvider>();

            _inputHandler = _container.Resolve<MainMenuInputHandler>();
            _inputHandler.Subscribe();
            
            yield break;
        }


        public override void Run()
        {
            Debug.Log("Start Menu Scene");
            
            Debug.Log($"2 - {GameMode.Letters}, 1 - {GameMode.Numbers}");
        }

        private void Update()
        {
            _selectGameModeService?.Update();
            

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