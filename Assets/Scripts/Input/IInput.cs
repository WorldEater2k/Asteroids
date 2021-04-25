using UnityEngine;

namespace Asteroids
{
    internal interface IInput
    {
        public bool AccelerationOn { get; }
        public bool AccelerationOff { get; }
        public bool FireOn { get; }
        public Vector3 LookDirection { get; }
        public float XAxis { get; }
        public float YAxis { get; }
    }
}