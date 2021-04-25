using UnityEngine;

namespace Asteroids
{
    internal sealed class PhysicsMove : IAccelerationMove
    {
        private readonly Rigidbody2D _rigidbody;
        public float Acceleration { get; private set; }
        public float Speed { get; private set; }

        public PhysicsMove(Rigidbody2D rigidbody, float speed, float acceleration)
        {
            Speed = speed;
            Acceleration = acceleration;
            _rigidbody = rigidbody;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _rigidbody.AddForce(new Vector2(horizontal, vertical) * deltaTime * Speed, ForceMode2D.Impulse);
        }

        public void AddAcceleration()
        {
            Speed += Acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= Acceleration;
        }
    }
}
