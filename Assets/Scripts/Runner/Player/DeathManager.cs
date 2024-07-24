using DG.Tweening;
using Scripts.Runner.Sections.Obstacles;
using UnityEngine;
using Zenject;

namespace Scripts.Runner.Player
{
    public class DeathManager : MonoBehaviour
    {
        private const float DeathAnimationTime = 0.5f;

        private GameManager _gameManager;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        [Inject]
        private void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Obstacle>() is Obstacle obstacle)
            {
                Debug.Log("Player is dead");

                _animator.SetTrigger(Constants.Triggers.DeathTrigger);

                switch (obstacle.ObstacleType)
                {
                    case EObstacleType.BottomObstacle:
                        FallForwards();
                        break;
                    default:
                        FallBackwards();
                        break;
                }

                var obstacleBatch = obstacle.transform.parent.gameObject;
                _gameManager.OnPlayerDeath(obstacleBatch);
            }
        }

        private void FallForwards() => RotateXAnimated(80f);

        private void FallBackwards() => RotateXAnimated(-80f);

        private void RotateXAnimated(float x) =>
            transform.DORotate(new Vector3(x, transform.rotation.y, transform.rotation.z), DeathAnimationTime);
    }
}
