using UnityEngine;

namespace Scripts.Runner.Player.PlayerStates
{
    public class RunningState : PlayerState
    {
        private readonly IInputHandler _inputHandler;

        public RunningState(
            PlayerMovement playerMovement,
            Animator animator,
            IInputHandler inputHandler) : base(playerMovement, animator)
        {
            _inputHandler = inputHandler;
        }

        public override void Enter()
        {
            Animator.SetTrigger(Constants.Triggers.RunTrigger);
        }

        public override void Update()
        {
            _inputHandler.HandleInput();
        }
    }
}
