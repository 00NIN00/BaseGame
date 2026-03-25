using System;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private ReactiveVariable<int> _field;
        private ReactiveVariable<int> _field2;
        
        private List<IDisposable> _disposables = new();

        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistration.Process(container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Initializing Menu Scene");

            yield break;
        }


        public override void Run()
        {
            Debug.Log("Start Menu Scene");
            
            Debug.Log($"2 - {GameMode.Letters}, 1 - {GameMode.Numbers}");

            _field = new ReactiveVariable<int>(5);
            _field2 = new ReactiveVariable<int>(15);
            
            IDisposable disposable = _field.Subscribe(OnFieldChanged);
            IDisposable disposable2 = _field2.Subscribe(OnFieldChanged);
            
            _disposables.Add(disposable);
            _disposables.Add(disposable2);
        }

        private void OnFieldChanged(int arg1, int arg2)
        {
            Debug.Log($"старое значение: {arg1}, новое: {arg2}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                LoadSceneGameplay(GameMode.Numbers);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                LoadSceneGameplay(GameMode.Letters);

            if (Input.GetKeyDown(KeyCode.F))
            {
                _field.Value += 1;
                _field2.Value += 1;

                foreach (IDisposable disposable in _disposables)
                {
                    disposable.Dispose();
                }
                
                _disposables.Clear();
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