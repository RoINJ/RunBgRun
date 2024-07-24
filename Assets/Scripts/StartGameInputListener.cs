using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Scripts
{
    public class StartGameInputListener : MonoBehaviour
    {
        private GameManager _gameManager;

        [Inject]
        private void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Update()
        {
            HandleInputs();
        }

        private void HandleInputs()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _gameManager.StartGame();
            }
        }
    }
}
