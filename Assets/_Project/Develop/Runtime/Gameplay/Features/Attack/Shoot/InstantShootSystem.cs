using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack.Shoot
{
    public class InstantShootSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _attackDelayEndEvent;

        private ReactiveVariable<float> _damage;
        private Transform _shootPoint;

        private IDisposable _attackDelayEndDisposable;

        public void OnInit(Entity entity)
        {
            _attackDelayEndEvent = entity.AttackDelayEndEvent;

            _damage = entity.InstantAttackDamage;
            _shootPoint = entity.ShootPoint;

            _attackDelayEndDisposable = _attackDelayEndEvent.Subscribe(OnAttackDelayEnd);
        }

        private void OnAttackDelayEnd()
        {
            Debug.Log($"Shoot, damage:{_damage.Value}, pointShoot:{_shootPoint.position}");
        }

        public void OnDispose()
        {
            _attackDelayEndDisposable.Dispose();
        }
    }
}