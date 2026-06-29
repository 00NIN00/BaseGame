namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection =>  MoveDirectionC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed =>  MoveSpeedC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed RotationSpeedC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed =>  RotationSpeedC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection RotationDirectionC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection =>  RotationDirectionC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessTimerSystem DeathProcessTimerSystemC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessTimerSystem>();

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessTimerSystem()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessTimerSystem() ); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth =>  CurrentHealthC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxHealth =>  MaxHealthC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead =>  IsDeadC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime =>  DeathProcessInitialTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime =>  DeathProcessCurrentTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess InDeadProcessC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InDeadProcess =>  InDeadProcessC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess()
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody =>  RigidbodyC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController =>  CharacterControllerC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.TransformComponent TransformC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform =>  TransformC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
		return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.TransformComponent() {Value = value}); 
		}

	}
}
