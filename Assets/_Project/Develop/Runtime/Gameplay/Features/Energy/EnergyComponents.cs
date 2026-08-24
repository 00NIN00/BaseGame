using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
   public class MaxEnergy : IEntityComponent
   {
      public ReactiveVariable<float> Value;
   }
   
   public class CurrentEnergy : IEntityComponent
   {
      public ReactiveVariable<float> Value;
   }
}