using System;
using UnityEngine;

namespace Asteroids
{
    internal delegate void SimpleDelegate();

    [CreateAssetMenu(fileName = "New PlayerStats", menuName = "PlayerStats", order = 51)]
    internal sealed class PlayerStats : ScriptableObject
    {
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private int _maxHp = 100;
        [SerializeField] private int _currentHp = 100;
        [SerializeField] private float _attackForce = 10.0f;
        public event SimpleDelegate PlayerDead;

        public float Acceleration { get; set; } = 0.5f;
        public float Speed
        {
            get => _speed;
            set
            {
                if (value >= 0)
                    _speed = value;
                else
                    throw new ArgumentException("Скорость не может быть отрицательной.");
            }
        }

        public int MaxHp
        {
            get => _maxHp;
            set
            {
                if (value > 0)
                    _maxHp = value;
                else
                    throw new ArgumentException("Максимальное кол-во жизней должно быть положительным.");
            }
        }
        public int Hp
        {
            get => _currentHp;
            set
            {
                if (value <= 0)
                    PlayerDead();
                else if (value > _maxHp)
                    throw new ArgumentException("Кол-во жизней не может превышать максимальное.");
                else
                    _currentHp = value;
            }
        }
        public float AttackForce
        {
            get => _attackForce;
            set
            {
                if (value > 0)
                    _speed = value;
                else
                    throw new ArgumentException("Сила атаки должна быть положительной.");
            }
        }
    }
}
