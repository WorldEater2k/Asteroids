using UnityEngine;

namespace Asteroids
{
    internal sealed class PlayerController : IExecute
    {
        private readonly Ship _ship;
        private readonly IInput _input;
        private readonly Camera _camera;
        private readonly PlayerStats _stats;
        private readonly Transform _playerTransform;

        public PlayerController(Ship ship, IInput input, Transform playerTransform, PlayerStats stats)
        {
            _ship = ship;
            _input = input;
            _playerTransform = playerTransform;
            _stats = stats;
            _camera = Camera.main;
        }

        public void Execute()
        {
            var direction = _input.LookDirection - _camera.WorldToScreenPoint(_playerTransform.position);
            _ship.Rotate(direction);
            _ship.Move(_input.XAxis, _input.YAxis, Time.deltaTime);

            if (_input.AccelerationOn)
                _ship.AddAcceleration();
            if (_input.AccelerationOff)
                _ship.RemoveAcceleration();

            if (_input.FireOn)
                _ship.Attack(_stats.AttackForce);
        }
        public void AddToExecuteList()
        {
            Executor.AddExecuteItem(this);
        }
        public void RemoveFromExecuteList()
        {
            Executor.RemoveExecuteItem(this);
        }
    }
}
