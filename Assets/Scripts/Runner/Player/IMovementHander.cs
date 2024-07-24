namespace Scripts.Runner.Player
{
    public interface IMovementHandler
    {
        void ChangeLane(int direction);

        public void Slide();

        public void Jump();

        void EndJump();

        void EndSlide();
    }
}