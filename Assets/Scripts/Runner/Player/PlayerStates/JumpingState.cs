namespace Scripts.Runner.Player.PlayerStates
{
    public class JumpingState : PlayerState
    {
        public JumpingState(PlayerMovement playerMovement) : base(playerMovement) { }

        public override void Enter()
        {
            PlayerMovement.DefaultCollider.enabled = false;
            PlayerMovement.JumpCollider.enabled = true;
            Animator.SetTrigger(Constants.Triggers.JumpTrigger);
        }

        public override void Exit()
        {
            PlayerMovement.DefaultCollider.enabled = true;
            PlayerMovement.JumpCollider.enabled = false;
        }
    }
}
