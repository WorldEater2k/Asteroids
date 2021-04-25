using UnityEngine;

namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        private Camera _camera;
        private GameObject _player;
        private void Start()
        {
            _camera = Camera.main;
            var stats = Resources.Load<PlayerStats>("ScriptableObjects/PlayerStats");
            _player = GameObject.FindGameObjectWithTag("Player");

            var physicsMove = new PhysicsMove(_player.GetComponent<Rigidbody2D>(), stats.Speed, stats.Acceleration);
            var rotation = new ShipRotator(_player.transform);
            var bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
            var attack = new BulletAttack(bulletPrefab, _player.transform.Find("Barrel"));

            var ship = new Ship(physicsMove, rotation, attack);
            var input = new InputPC();

            var playerController = new PlayerController(ship, input, _player.transform, stats);
            playerController.AddToExecuteList();
        }
        private void Update()
        {
            Executor.ExecuteAll();
            var playerPos = _player.transform.position;
            _camera.transform.position = new Vector3(playerPos.x, playerPos.y + 1.0f, playerPos.z - 10.0f);
        }

        private void OnDestroy()
        {
            Executor.RemoveAll();
        }
    }
}
