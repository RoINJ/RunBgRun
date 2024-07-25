namespace Scripts.Runner.Player.PlayerStates
{
    public class SlidingState : PlayerState
    {
        public SlidingState(PlayerMovement playerMovement) : base(playerMovement)
        {
        }

        public override void Enter()
        {
            PlayerMovement.DefaultCollider.enabled = false;
            PlayerMovement.SlideCollider.enabled = true;
            Animator.SetTrigger(Constants.Triggers.SlideTrigger);
        }

        public override void Exit()
        {
            PlayerMovement.DefaultCollider.enabled = true;
            PlayerMovement.SlideCollider.enabled = false;
        }
    }
}
