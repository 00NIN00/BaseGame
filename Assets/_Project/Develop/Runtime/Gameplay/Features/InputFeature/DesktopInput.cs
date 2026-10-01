using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public class DesktopInput : IInputService
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";
        private const string MouseXAxisName = "Mouse X";
        private const int AttackMouseButton = 0;
        public bool IsEnabled { get; set; } = true;

        public Vector3 Direction
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;
                
                return new Vector3(UnityEngine.Input.GetAxisRaw(HorizontalAxisName), 0, UnityEngine.Input.GetAxisRaw(VerticalAxisName));
            }
        }
        
        public float RotationDelta
        {
            get
            {
                if (IsEnabled == false)
                    return 0f;

                return UnityEngine.Input.GetAxisRaw(MouseXAxisName);
            }
        }
        
        public bool IsAttackPressed
        {
            get
            {
                if (IsEnabled == false)
                    return false;

                return UnityEngine.Input.GetMouseButtonDown(AttackMouseButton);
            }
        }
    }
}