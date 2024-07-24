using UnityEngine;

namespace Scripts.Runner.Player
{
    public class SwipesInputHandler : IInputHandler
    {
        private const float SwipeThreshold = 5f;
        private bool _actionPerformed;

        private IMovementHandler _movementHandler;

        public SwipesInputHandler(IMovementHandler playerMovement)
        {
            _movementHandler = playerMovement;
        }

        public void HandleInput()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Ended)
                {
                    _actionPerformed = false;
                }

                if (touch.phase == TouchPhase.Moved && !_actionPerformed)
                {
                    _actionPerformed = true;
                    HandleTouch(touch);
                }
            }
        }

        private void HandleTouch(Touch touch)
        {
            var swipeDelta = touch.deltaPosition;

            var absoluteX = Mathf.Abs(swipeDelta.x);
            var absoluteY = Mathf.Abs(swipeDelta.y);

            Debug.Log(swipeDelta);

            if (absoluteX > SwipeThreshold || absoluteY > SwipeThreshold)
            {
                if (absoluteX > absoluteY)
                {
                    HandleHorizontalSwipe(swipeDelta);
                }
                else
                {
                    HandleVerticalSwipe(swipeDelta);
                }
            }
        }

        private void HandleHorizontalSwipe(Vector2 swipeDelta)
        {
            var laneDelta = swipeDelta.x > 0 ? 1 : -1;
            _movementHandler.ChangeLane(laneDelta);
        }

        private void HandleVerticalSwipe(Vector2 swipeDelta)
        {
            if (swipeDelta.y > 0)
            {
                _movementHandler.Jump();
            }
            else
            {
                _movementHandler.Slide();
            }
        }
    }
}
