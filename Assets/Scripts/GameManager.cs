using System;
using Scripts.Runner;
using Scripts.Runner.Player;
using Scripts.Runner.Score;
using Scripts.Runner.Sections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement _playerMovement;

        [SerializeField]
        private GameMenuUIManager _gameMenuUIManager;

        private ScoreManager _scoreManager;
        private RunSpeedManager _runSpeedManager;

        private EGameState _gameState;

        private AdManager _adManager;

        [Inject]
        private void Init(AdManager adManager)
        {
            _adManager = adManager;
        }

        private void Start()
        {
            _playerMovement.enabled = false;

            _scoreManager = GetComponent<ScoreManager>();
            _runSpeedManager = GetComponent<RunSpeedManager>();
        }

        private void Update()
        {
            if (_gameState == EGameState.MainMenu)
            {
                HandleInputs();
            }
        }

        private void HandleInputs()
        {
            if (Input.GetKeyDown(KeyCode.Space) ||
                (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            var sections = FindObjectsOfType<SectionMovement>();
            Array.ForEach(sections, s => s.enabled = true);

            _playerMovement.enabled = true;

            _scoreManager.enabled = true;
            _runSpeedManager.enabled = true;
        }

        public void OnPlayerDeath()
        {
            var sections = FindObjectsOfType<SectionMovement>();
            Array.ForEach(sections, s => s.enabled = false);

            _playerMovement.enabled = false;

            _scoreManager.enabled = false;
            _runSpeedManager.enabled = false;

            _gameMenuUIManager.ShowDeathPanel();
        }

        public void ToMainMenu()
        {
            var currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        public void ShowAdToRespawn()
        {
            _adManager.ShowRewardedAd(Respawn);
        }

        private void Respawn()
        {
            var sections = FindObjectsOfType<SectionMovement>();
            Array.ForEach(sections, s => s.enabled = true);

            _playerMovement.enabled = true;

            _scoreManager.enabled = true;
            _runSpeedManager.enabled = true;

            _gameMenuUIManager.ShowInGameMenu();
        }
    }
}
