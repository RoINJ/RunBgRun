using DG.Tweening;
using Scripts.Runner.Player.PlayerStates;
using UnityEngine;

namespace Scripts.Runner.Player
{
    public class PlayerMovement : MonoBehaviour, IMovementHandler
    {
        private const float SwitchLineAnimationDuration = 0.3f;

        [SerializeField]
        private Collider _defaultCollider;

        [SerializeField]
        private Collider _jumpCollider;

        [SerializeField]
        private Collider _slideCollider;

        [SerializeField]
        private Animator _animator;

        private int _currentLane;

        private float _startPositionX;
        private PlayerState _currentState;
        private IInputHandler _inputHandler;

        public Collider DefaultCollider => _defaultCollider;
        public Collider JumpCollider => _jumpCollider;
        public Collider SlideCollider => _slideCollider;

        public void ChangeLane(int direction)
        {
            var targetLane = _currentLane + direction;
            if (targetLane >= -1 && targetLane <= 1)
            {
                transform.DOMoveX(targetLane + _startPositionX, SwitchLineAnimationDuration);
                _currentLane = targetLane;
            }
        }

        public void Slide() => SetState(new SlidingState(this, _animator));

        public void EndSlide() => Run();

        public void Jump() => SetState(new JumpingState(this, _animator));

        public void EndJump() => Run();

        private void Run() => SetState(new RunningState(this, _animator, _inputHandler));

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
            Run();
        }

        private void Update()
        {
            _currentState.Update();
        }

        private void SetState(PlayerState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}
