using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage
{

    /// <summary>
    /// Приоритет для AreaDamage: 2
    /// </summary>
    public class AreaDamageEntitiesFilterSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contacts;
        private Buffer<Entity> _targets;
        private Entity _self;

        private readonly CollidersRegistryService _collidersRegistryService;

        public AreaDamageEntitiesFilterSystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _contacts = entity.AreaDamageContactsBuffer;
            _targets = entity.AreaDamageTargetsBuffer;
            _self = entity;
        }

        public void OnUpdate(float deltaTime)
        {
            _targets.Count = 0;

            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _collidersRegistryService.GetBy(_contacts.Items[i]);

                if (contactEntity != null && contactEntity != _self)
                {
                    _targets.Items[_targets.Count] = contactEntity;
                    _targets.Count++;
                }
            }
        }
    }
}