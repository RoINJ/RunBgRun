using UnityEngine;

namespace Scripts.Runner.Player.PlayerStates
{
    public class RunningState : PlayerState
    {
        private IInputHandler _inputHandler;

        public RunningState(PlayerMovement playerMovement, IInputHandler inputHandler) : base(playerMovement)
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
