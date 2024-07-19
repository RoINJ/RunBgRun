using UnityEngine;

namespace Scripts.Runner
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement _playerMovement;

        private void Update()
        {
            HandleSwipesInput();
            HandleKeysInput();
        }

        private void HandleSwipesInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    Vector2 swipeDelta = touch.deltaPosition;
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

        private void HandleKeysInput()
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
