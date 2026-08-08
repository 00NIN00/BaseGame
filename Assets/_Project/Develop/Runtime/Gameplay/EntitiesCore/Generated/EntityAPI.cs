namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportRadius TeleportRadiusC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportRadius>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TeleportRadius => TeleportRadiusC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportRadius()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportRadius() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportRadius(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportRadius() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.DamageOnTeleport DamageOnTeleportC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.DamageOnTeleport>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DamageOnTeleport => DamageOnTeleportC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDamageOnTeleport()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.DamageOnTeleport() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDamageOnTeleport(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.DamageOnTeleport() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.DamageRadiusOnTeleport DamageRadiusOnTeleportC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.DamageRadiusOnTeleport>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DamageRadiusOnTeleport => DamageRadiusOnTeleportC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDamageRadiusOnTeleport()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.DamageRadiusOnTeleport() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDamageRadiusOnTeleport(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.DamageRadiusOnTeleport() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportEnergyCost TeleportEnergyCostC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportEnergyCost>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TeleportEnergyCost => TeleportEnergyCostC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportEnergyCost()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportEnergyCost() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportEnergyCost(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportEnergyCost() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportCooldownInitialTime TeleportCooldownInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportCooldownInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TeleportCooldownInitialTime => TeleportCooldownInitialTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCooldownInitialTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportCooldownInitialTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCooldownInitialTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportCooldownInitialTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportCooldownCurrentTime TeleportCooldownCurrentTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportCooldownCurrentTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TeleportCooldownCurrentTime => TeleportCooldownCurrentTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCooldownCurrentTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportCooldownCurrentTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCooldownCurrentTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportCooldownCurrentTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.InTeleportCooldown InTeleportCooldownC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.InTeleportCooldown>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InTeleportCooldown => InTeleportCooldownC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInTeleportCooldown()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.InTeleportCooldown() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInTeleportCooldown(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.InTeleportCooldown() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.SelectedTeleportPoint SelectedTeleportPointC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.SelectedTeleportPoint>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> SelectedTeleportPoint => SelectedTeleportPointC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSelectedTeleportPoint()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.SelectedTeleportPoint() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSelectedTeleportPoint(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.SelectedTeleportPoint() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.CanTeleport CanTeleportC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.CanTeleport>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanTeleport => CanTeleportC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanTeleport(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.CanTeleport() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportRequest TeleportRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent TeleportRequest => TeleportRequestC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportPointSelectedEvent TeleportPointSelectedEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportPointSelectedEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> TeleportPointSelectedEvent => TeleportPointSelectedEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportPointSelectedEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportPointSelectedEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportPointSelectedEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportPointSelectedEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportExecutedEvent TeleportExecutedEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportExecutedEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> TeleportExecutedEvent => TeleportExecutedEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportExecutedEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportExecutedEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportExecutedEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Teleport.TeleportExecutedEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(_Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(_Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask DeathMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageRadius AreaDamageRadiusC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageRadius>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AreaDamageRadius => AreaDamageRadiusC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaDamageRadius()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageRadius() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaDamageRadius(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageRadius() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageMask AreaDamageMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageMask>();

		public UnityEngine.LayerMask AreaDamageMask => AreaDamageMaskC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaDamageMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageContactsBuffer AreaDamageContactsBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageContactsBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> AreaDamageContactsBuffer => AreaDamageContactsBufferC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaDamageContactsBuffer(_Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageContactsBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageTargetsBuffer AreaDamageTargetsBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageTargetsBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> AreaDamageTargetsBuffer => AreaDamageTargetsBufferC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaDamageTargetsBuffer(_Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaDamage.AreaDamageTargetsBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove CanMoveC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving IsMovingC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed RotationSpeedC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection RotationDirectionC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotation CanRotationC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotation>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanRotation => CanRotationC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotation(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotation() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie MustDieC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess InDeadProcessC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InDeadProcess => InDeadProcessC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() { Value = new System.Collections.Generic.List<UnityEngine.Collider>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.MaxEnergy MaxEnergyC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.MaxEnergy>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxEnergy => MaxEnergyC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxEnergy()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.MaxEnergy() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxEnergy(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.MaxEnergy() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.CurrentEnergy CurrentEnergyC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.CurrentEnergy>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentEnergy => CurrentEnergyC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentEnergy()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.CurrentEnergy() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentEnergy(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.CurrentEnergy() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenPercentage EnergyRegenPercentageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenPercentage>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyRegenPercentage => EnergyRegenPercentageC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRegenPercentage()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenPercentage() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRegenPercentage(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenPercentage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenIntervalInitialTime EnergyRegenIntervalInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenIntervalInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyRegenIntervalInitialTime => EnergyRegenIntervalInitialTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRegenIntervalInitialTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenIntervalInitialTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRegenIntervalInitialTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenIntervalInitialTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenIntervalCurrentTime EnergyRegenIntervalCurrentTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenIntervalCurrentTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyRegenIntervalCurrentTime => EnergyRegenIntervalCurrentTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRegenIntervalCurrentTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenIntervalCurrentTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRegenIntervalCurrentTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenIntervalCurrentTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.InEnergyRegenCooldown InEnergyRegenCooldownC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.InEnergyRegenCooldown>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InEnergyRegenCooldown => InEnergyRegenCooldownC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInEnergyRegenCooldown()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.InEnergyRegenCooldown() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInEnergyRegenCooldown(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.InEnergyRegenCooldown() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.CanRegenEnergy CanRegenEnergyC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.CanRegenEnergy>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanRegenEnergy => CanRegenEnergyC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRegenEnergy(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.CanRegenEnergy() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.CanSpendEnergy CanSpendEnergyC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.CanSpendEnergy>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanSpendEnergy => CanSpendEnergyC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanSpendEnergy(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.CanSpendEnergy() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.CanAddEnergy CanAddEnergyC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.CanAddEnergy>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanAddEnergy => CanAddEnergyC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanAddEnergy(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.CanAddEnergy() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergyRequest RegenEnergyRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergyRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent RegenEnergyRequest => RegenEnergyRequestC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRegenEnergyRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergyRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRegenEnergyRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergyRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergyEvent RegenEnergyEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergyEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent RegenEnergyEvent => RegenEnergyEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRegenEnergyEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergyEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRegenEnergyEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.RegenEnergyEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergyRequest SpendEnergyRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergyRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> SpendEnergyRequest => SpendEnergyRequestC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpendEnergyRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergyRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpendEnergyRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergyRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergyEvent SpendEnergyEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergyEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> SpendEnergyEvent => SpendEnergyEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpendEnergyEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergyEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpendEnergyEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.SpendEnergyEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergyRequest AddEnergyRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergyRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> AddEnergyRequest => AddEnergyRequestC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAddEnergyRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergyRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAddEnergyRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergyRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergyEvent AddEnergyEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergyEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> AddEnergyEvent => AddEnergyEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAddEnergyEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergyEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAddEnergyEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.AddEnergyEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanStartAttack => CanStartAttackC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint ShootPointC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack MustCancelAttackC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustCancelAttack => MustCancelAttackC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustCancelAttack(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent AttackCancelEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackCancelEvent => AttackCancelEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCancelEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCancelEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage.AreaDamageAmount AreaDamageAmountC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage.AreaDamageAmount>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AreaDamageAmount => AreaDamageAmountC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaDamageAmount()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage.AreaDamageAmount() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaDamageAmount(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage.AreaDamageAmount() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage.CanAreaDamage CanAreaDamageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage.CanAreaDamage>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanAreaDamage => CanAreaDamageC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanAreaDamage(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.AreaTakeDamage.CanAreaDamage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage CanApplyDamageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplyDamage(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.TransformComponent TransformC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.TransformComponent() {Value = value}); 
		}

	}
}
