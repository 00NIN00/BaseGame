using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Gameplay;
using System.Collections;
using System.Collections.Generic;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Utilities.DataManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.DataManagement.DataRepository;
using _Project.Develop.Runtime.Utilities.DataManagement.Serializers;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private WalletService _walletService;

        private PlayerDataProvider _playerDataProvider;

        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistration.Process(container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Initializing Menu Scene");

            _walletService = _container.Resolve<WalletService>();

            _playerDataProvider = _container.Resolve<PlayerDataProvider>();
            
            yield break;
        }


        public override void Run()
        {
            Debug.Log("Start Menu Scene");

            Debug.Log($"2 - {GameMode.Letters}, 1 - {GameMode.Numbers}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                LoadSceneGameplay(GameMode.Numbers);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                LoadSceneGameplay(GameMode.Letters);

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _walletService.Add(CurrencyType.Gold, 10);
                Debug.Log("Gold Added current: " + _walletService.GetCurrency(CurrencyType.Gold).Value);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (_walletService.Enough(CurrencyType.Gold, 10) == false)
                    return;

                _walletService.Spend(CurrencyType.Gold, 10);
                Debug.Log("Gold Spent current: " + _walletService.GetCurrency(CurrencyType.Gold).Value);
            }

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
        

        private void LoadSceneGameplay(GameMode gameMode)
        {
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinePerformer = _container.Resolve<ICoroutinesPerformer>();

            GameplayInputArgs args = new GameplayInputArgs(gameMode);

            coroutinePerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, args));
        }
        
    }
}