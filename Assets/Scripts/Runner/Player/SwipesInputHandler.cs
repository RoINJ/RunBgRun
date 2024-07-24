using UnityEngine;

namespace Scripts.Runner.Player
{
    public class SwipesInputHandler : IInputHandler
    {
        private PlayerMovement _playerMovement;

        public SwipesInputHandler(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        public void HandleInput()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    var swipeDelta = touch.deltaPosition;
                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                    {
                        var laneDelta = swipeDelta.x > 0 ? 1 : -1;
                        _playerMovement.ChangeLane(laneDelta);
                    }
                    else
                    {
                        if (swipeDelta.y > 0)
                        {
                            _playerMovement.Jump();
                        }
                        else
                        {
                            _playerMovement.Slide();
                        }
                    }
                }
            }
        }
    }
}
