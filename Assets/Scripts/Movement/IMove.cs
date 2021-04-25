namespace Asteroids
{
    public interface IMove
    {
        public float Speed { get; }
        public void Move(float horizontal, float vertical, float deltaTime);
    }
}
