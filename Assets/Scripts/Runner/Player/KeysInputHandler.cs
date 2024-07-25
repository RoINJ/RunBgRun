using UnityEngine;

namespace Scripts.Runner.Player
{
    public class KeysInputHandler : IInputHandler
    {
        private readonly IMovementHandler _movementHandler;

        public KeysInputHandler(IMovementHandler movementHandler)
        {
            _movementHandler = movementHandler;
        }

        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                _movementHandler.ChangeLane(-1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                _movementHandler.ChangeLane(1);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                _movementHandler.Jump();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                _movementHandler.Slide();
            }
        }
    }
}
