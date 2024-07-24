using DG.Tweening;
using UnityEngine;

namespace Scripts.Runner.Player
{
    public class PlayerMovement : MonoBehaviour, IMovementHandler
    {
        private const float _switchLineAnimationDuration = 0.3f;

        [SerializeField]
        private Collider _defaultCollider;

        [SerializeField]
        private Collider _jumpCollider;

        [SerializeField]
        private Collider _slideCollider;

        private Animator _animator;

        private int _currentLane = 0;

        private ECurrentAction _currentAction = ECurrentAction.None;

        private IInputHandler _inputHandler;
        private float _startPositionX;

        private void Start()
        {
            _startPositionX = transform.position.x;

#if (UNITY_ANDROID || UNITY_IOS) && !DEBUG
            _inputHandler = new SwipesInputHandler(this);
#else
            _inputHandler = new KeysInputHandler(this);
#endif
        }

        private void OnEnable()
        {
            StartRun();
        }

        private void Update()
        {
            _inputHandler.HandleInput();
        }

        private void FixedUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        private void StartRun()
        {
            _animator = GetComponentInChildren<Animator>();
            _animator.SetTrigger(Constants.Triggers.RunTrigger);
        }

        public void ChangeLane(int direction)
        {
            if (_currentAction == ECurrentAction.None)
            {
                var targetLane = _currentLane + direction;
                if (targetLane >= -1 && targetLane <= 1)
                {
                    transform.DOMoveX(targetLane + _startPositionX, _switchLineAnimationDuration);
                    _currentLane = targetLane;
                }
            }
        }

        public void Slide()
        {
            if (_currentAction == ECurrentAction.None)
            {
                _currentAction = ECurrentAction.Slide;

                _defaultCollider.enabled = false;
                _slideCollider.enabled = true;

                _animator.SetTrigger(Constants.Triggers.SlideTrigger);
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
            if (_currentAction == ECurrentAction.None)
            {
                _currentAction = ECurrentAction.Jump;

                _defaultCollider.enabled = false;
                _jumpCollider.enabled = true;

                _animator.SetTrigger(Constants.Triggers.JumpTrigger);
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
