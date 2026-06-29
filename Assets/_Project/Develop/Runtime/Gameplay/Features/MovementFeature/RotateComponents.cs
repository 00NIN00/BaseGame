using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
  public class RotationSpeed : IEntityComponent
  {
      public ReactiveVariable<float> Value;
  }

  public class RotationDirection : IEntityComponent
  {
      public ReactiveVariable<Vector3> Value;
  }

  public class CanRotation : IEntityComponent
  {
      public ICompositeCondition Value;
  }
}