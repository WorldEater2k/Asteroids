namespace Asteroids
{
    internal interface IAccelerationMove : IMove
    {
        public float Acceleration { get; }
        public void AddAcceleration();
        public void RemoveAcceleration();

    }
}
