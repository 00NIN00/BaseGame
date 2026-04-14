using System;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Gameplay.Input;
using _Project.Develop.Runtime.Gameplay.View;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Gameplay;
using System.Collections;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private SelectGameModeService _selectGameModeService;
        
        private WalletService _walletService;

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
            _walletService = _container.Resolve<WalletService>();

            _playerDataProvider = _container.Resolve<PlayerDataProvider>();

            _inputHandler = new MainMenuInputHandler(_container.Resolve<IInput>(), _container, new ViewStats(_walletService, _container.Resolve<OutcomesCounterService>()));
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
            _inputHandler.UnSubscribe();
        }
    }
}