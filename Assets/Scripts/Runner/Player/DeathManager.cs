using DG.Tweening;
using Scripts.Runner.Sections.Obstacles;
using UnityEngine;
using Zenject;

namespace Scripts.Runner.Player
{
    public class DeathManager : MonoBehaviour
    {
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

                _animator.speed = 0;

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

        private void FallForwards() =>
            transform.DORotate(new Vector3(80f, transform.rotation.y, transform.rotation.z), 0.5f);

        private void FallBackwards() =>
            transform.DORotate(new Vector3(-80f, transform.rotation.y, transform.rotation.z), 0.5f);
    }
}
