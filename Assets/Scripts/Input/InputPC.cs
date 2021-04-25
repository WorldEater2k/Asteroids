using UnityEngine;

namespace Asteroids
{
    internal sealed class InputPC : IInput
    {
        public bool AccelerationOn => Input.GetKeyDown(KeyCode.LeftShift);
        public bool AccelerationOff => Input.GetKeyUp(KeyCode.LeftShift);
        public bool FireOn => Input.GetButtonDown("Fire1");
        public Vector3 LookDirection => Input.mousePosition;
        public float XAxis => Input.GetAxis("Horizontal");
        public float YAxis => Input.GetAxis("Vertical");
    }
}
