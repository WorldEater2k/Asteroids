using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class Player : MonoBehaviour
    {
        private PlayerStats _stats;

        private void Start()
        {
            _stats = Resources.Load<PlayerStats>("ScriptableObjects/PlayerStats");
            _stats.PlayerDead += Die;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _stats.Hp--;
        }

        private void OnDestroy()
        {
            _stats.PlayerDead -= Die;
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
