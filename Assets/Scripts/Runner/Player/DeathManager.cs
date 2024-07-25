using Scripts.Runner.Sections.Obstacles;
using UnityEngine;
using Zenject;

namespace Scripts.Runner.Player
{
    public class DeathManager : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private GameManager _gameManager;

        [Inject]
        private void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Obstacle>(out var obstacle))
            {
                Debug.Log("Player is dead");

                var fallDirection = obstacle.ObstacleType == EObstacleType.BottomObstacle
                    ? Vector3.right
                    : Vector3.left;
                
                _playerMovement.Die(fallDirection);

                var obstacleBatch = obstacle.transform.parent.gameObject;
                _gameManager.OnPlayerDeath(obstacleBatch);
            }
        }

        
    }
}
