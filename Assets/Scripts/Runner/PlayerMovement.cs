using UnityEngine;

namespace Scripts.Runner
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private Collider _defaultCollider;

        [SerializeField]
        private Collider _jumpCollider;

        [SerializeField]
        private Collider _slideCollider;

        private Animator _animator;

        public float laneDistance = 2.0f; // Distance between lanes

        private int currentLane = 0; // -1 for left, 0 for middle, 1 for right

        private ECurrentAction _currentAction = ECurrentAction.None;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _animator.SetTrigger("RunTrigger");
        }

        private void FixedUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        public void ChangeLane(int direction)
        {
            Debug.Log("Change lane");

            if (_currentAction == ECurrentAction.None)
            {
                var targetLane = currentLane + direction;
                if (targetLane >= -1 && targetLane <= 1)
                {
                    currentLane = targetLane;
                    var deltaPosition = new Vector3(direction * laneDistance, 0, 0);
                    transform.position += deltaPosition;
                }
            }
        }

        public void Slide()
        {
            Debug.Log("Slide");

            if (_currentAction == ECurrentAction.None)
            {
                _currentAction = ECurrentAction.Slide;

                _defaultCollider.enabled = false;
                _slideCollider.enabled = true;

                _animator.SetTrigger("SlideTrigger");
            }
        }

        public void EndSlide()
        {
            _currentAction = ECurrentAction.None;

            _slideCollider.enabled = false;
            _defaultCollider.enabled = true;
        }

        public void Jump()
        {
            Debug.Log("Jump");

            if (_currentAction == ECurrentAction.None)
            {
                _currentAction = ECurrentAction.Jump;

                _defaultCollider.enabled = false;
                _jumpCollider.enabled = true;

                _animator.SetTrigger("JumpTrigger");
            }
        }

        public void EndJump()
        {
            _currentAction = ECurrentAction.None;

            _jumpCollider.enabled = false;
            _defaultCollider.enabled = true;
        }
    }
}
