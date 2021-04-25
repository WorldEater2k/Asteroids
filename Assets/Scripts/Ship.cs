using System;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation, IAttack
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly IAttack _attackImplementation;

        public float Speed => _moveImplementation.Speed;

        public Ship(IMove moveImplementation, IRotation rotationImplementation, IAttack attackImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _attackImplementation = attackImplementation;
        }

        public void Attack(float force)
        {
            _attackImplementation.Attack(force);
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is IAccelerationMove accelerationMove)
                accelerationMove.AddAcceleration();
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is IAccelerationMove accelerationMove)
                accelerationMove.RemoveAcceleration();
        }

        public void Rotate(Vector3 direction)
        {
            _rotationImplementation.Rotate(direction);
        }
    }
}
