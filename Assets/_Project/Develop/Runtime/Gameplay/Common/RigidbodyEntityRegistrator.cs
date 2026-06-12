using _Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Common
{
    public class RigidbodyEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddRigidbody(GetComponent<Rigidbody>());
        }
    }
}