using DG.Tweening;
using Scripts.Runner.Player.PlayerStates;
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

        private int _currentLane = 0;

        private float _startPositionX;
        private PlayerState _currentState;
        private IInputHandler _inputHandler;

        public Collider DefaultCollider => _defaultCollider;
        public Collider JumpCollider => _jumpCollider;
        public Collider SlideCollider => _slideCollider;

        private void Awake()
        {
            _startPositionX = transform.position.x;

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _inputHandler = new SwipesInputHandler(this);
#else
            _inputHandler = new KeysInputHandler(this);
#endif
        }

        private void OnEnable()
        {
            SetState(new RunningState(this, _inputHandler));
        }

        private void Update()
        {
            _currentState.Update();
        }

        public void ChangeLane(int direction)
        {
            var targetLane = _currentLane + direction;
            if (targetLane >= -1 && targetLane <= 1)
            {
                transform.DOMoveX(targetLane + _startPositionX, _switchLineAnimationDuration);
                _currentLane = targetLane;
            }
        }

        public void Slide() => SetState(new SlidingState(this));

        public void EndSlide() => SetState(new RunningState(this, _inputHandler));

        public void Jump() => SetState(new JumpingState(this));

        public void EndJump() => SetState(new RunningState(this, _inputHandler));

        private void SetState(PlayerState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}
