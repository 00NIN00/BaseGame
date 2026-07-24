using _Project.Develop.Runtime.Utilities.AssetsManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public class MonoEntitiesFactory : IInitializable, IDisposable
    {
        private readonly ResourcesAssetsLouder _resources;

        private readonly EntitiesLiveContext _entityToLiveContext;
        
        private readonly CollidersRegistryService _collidersRegistryService;
        
        private readonly Dictionary<Entity, MonoEntity> _entityToMono = new();
        
        public MonoEntitiesFactory(ResourcesAssetsLouder resources, EntitiesLiveContext entityToLiveContext, CollidersRegistryService collidersRegistryService)
        {
            _resources = resources;
            _entityToLiveContext = entityToLiveContext;
            _collidersRegistryService = collidersRegistryService;
        }

        public MonoEntity Create(Entity entity, Vector3 position, string path)
        {
            MonoEntity prefab = _resources.Load<MonoEntity>(path);
            
            MonoEntity viewInstance = Object.Instantiate(prefab, position, Quaternion.identity, null);
            
            viewInstance.Initialize(_collidersRegistryService);
            
            viewInstance.Link(entity);
            
            _entityToMono.Add(entity, viewInstance);
            
            return viewInstance;
        }

        public void Initialize()
        {
            _entityToLiveContext.Released += OnEntityReleased;
        }
        
        public void Dispose()
        {
            _entityToLiveContext.Released -= OnEntityReleased;

            foreach (Entity entity in _entityToMono.Keys)
                CleanupFor(entity);
            
            _entityToMono.Clear();
        }
        
        private void OnEntityReleased(Entity entity)
        {
            CleanupFor(entity);
            _entityToMono.Remove(entity);
        }

        private void CleanupFor(Entity entity)
        {
            MonoEntity monoEntity = _entityToMono[entity];
            monoEntity.Cleanup(entity);
            Object.Destroy(monoEntity.gameObject);
        }
    }
}