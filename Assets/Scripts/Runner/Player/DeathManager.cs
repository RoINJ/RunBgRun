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
            if (other.CompareTag("Obstacle"))
            {
                Debug.Log("Player is dead");

                _gameManager.OnPlayerDeath();
                //_animator.SetTrigger("DeathTrigger");
            }
        }
    }
}
