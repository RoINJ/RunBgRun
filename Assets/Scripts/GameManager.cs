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

        private AdManager _adManager;
        private ScoreSaver _scoreSaver;

        private GameObject _lastObstacle;

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

        public void StartGame()
        {
            SetGameRunning(true);

            _gameMenuUIManager.SetActivePanel(EGameMenuState.InGame);
        }

        public void OnPlayerDeath(GameObject obstacle)
        {
            _lastObstacle = obstacle;

            SetGameRunning(false);

            _gameMenuUIManager.SetActivePanel(EGameMenuState.DeathMenu);
        }

        public void Restart()
        {
            _scoreSaver.SaveScore();
            var currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        public void ShowAdToRespawn()
        {
            _adManager.ShowRewardedAd(Respawn);
        }

        private void Respawn()
        {
            Destroy(_lastObstacle);
            _lastObstacle = null;
            
            _playerMovement.GetComponent<RespawnHelper>().Respawn();
            StartGame();
        }

        private void SetGameRunning(bool isRunning)
        {
            var sections = FindObjectsOfType<SectionMovement>();
            Array.ForEach(sections, s => s.enabled = isRunning);

            _playerMovement.enabled = isRunning;

            _scoreManager.enabled = isRunning;
            _runSpeedManager.enabled = isRunning;
        }
    }
}
