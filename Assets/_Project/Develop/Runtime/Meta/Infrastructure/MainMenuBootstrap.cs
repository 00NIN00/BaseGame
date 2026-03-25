using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Gameplay;
using System.Collections;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        
        private WalletService _walletService;

        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistration.Process(container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Initializing Menu Scene");

            _walletService = _container.Resolve<WalletService>();
            
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