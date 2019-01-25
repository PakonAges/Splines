namespace DiUi
{
    public class CubeMovementSignal 
    {
        public MovementDirection Direction { get; private set; }

        public CubeMovementSignal(MovementDirection Direction)
        {
            this.Direction = Direction;
        }
    }

    public enum MovementDirection
    {
        Invalid,
        Right,
        Left,
        Stop
    }
}