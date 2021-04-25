using UnityEngine;

namespace Asteroids
{
    internal sealed class BulletAttack : IAttack
    {
        private readonly GameObject _bulletPrefab;
        private readonly Transform _barrel;

        public BulletAttack(GameObject bulletPrefab, Transform barrel)
        {
            _bulletPrefab = bulletPrefab;
            _barrel = barrel;
        }
        public void Attack(float force)
        {
            Rigidbody2D temAmmunition = Object.Instantiate(_bulletPrefab, _barrel.position, _barrel.rotation).GetComponent<Rigidbody2D>();
            temAmmunition.AddForce(_barrel.up * force);
        }
    }
}
