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
        private ScoreSaver _scoreSaver;

        [Inject]
        private void Init(AdManager adManager)
        {
            _adManager = adManager;
        }

        private void Start()
        {
            _playerMovement.enabled = false;

            _scoreManager = GetComponent<ScoreManager>();
            _scoreSaver = GetComponent<ScoreSaver>();
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
            _gameState = EGameState.Started;
            var sections = FindObjectsOfType<SectionMovement>();
            Array.ForEach(sections, s => s.enabled = true);

            _playerMovement.enabled = true;

            _scoreManager.enabled = true;
            _runSpeedManager.enabled = true;

            _gameMenuUIManager.ShowInGameMenu();
        }

        public void OnPlayerDeath()
        {
            _gameState = EGameState.PlayerDead;
            var sections = FindObjectsOfType<SectionMovement>();
            Array.ForEach(sections, s => s.enabled = false);

            _playerMovement.enabled = false;

            _scoreManager.enabled = false;
            _runSpeedManager.enabled = false;

            _gameMenuUIManager.ShowDeathPanel();
        }

        public void ToMainMenu()
        {
            _gameState = EGameState.MainMenu;
            _gameMenuUIManager.ShowMainMenu();
        }

        public void ShowScoreboard()
        {
            _gameState = EGameState.Scoreboard;
            _gameMenuUIManager.ShowScoreboard();
        }

        public void Restart()
        {
            _scoreSaver.SaveScore();
            var currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        public void ShowAdToRespawn()
        {
            _adManager.ShowRewardedAd(StartGame);
        }
    }
}
