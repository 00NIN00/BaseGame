using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using System.Collections;
using _Project.Develop.Runtime.Gameplay;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private SelectGameModeService _selectGameModeService;
        
        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistration.Process(container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Initializing Menu Scene");

            _selectGameModeService = _container.Resolve<SelectGameModeService>();
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
        }
    }
}