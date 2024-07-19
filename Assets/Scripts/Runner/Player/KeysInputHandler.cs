using UnityEngine;

namespace Scripts.Runner.Player
{
    public class KeysInputHandler : IInputHandler
    {
        private PlayerMovement _playerMovement;

        public KeysInputHandler(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                _playerMovement.ChangeLane(-1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                _playerMovement.ChangeLane(1);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                _playerMovement.Jump();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                _playerMovement.Slide();
            }
        }
    }
}
