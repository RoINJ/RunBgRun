using System;
using Scripts.Runner;
using Scripts.Runner.Player;
using Scripts.Runner.Score;
using Scripts.Runner.Sections;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _startGameLabel;

        [SerializeField]
        private PlayerMovement _playerMovement;

        private ScoreManager _scoreManager;
        private RunSpeedManager _runSpeedManager;

        private void Start()
        {
            _playerMovement.enabled = false;
            SetStartGameLabel();

            _scoreManager = GetComponent<ScoreManager>();
            _runSpeedManager = GetComponent<RunSpeedManager>();
        }

        private void SetStartGameLabel()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !DEBUG
            _startGameLabel.text = "Tap to start";
#else
            _startGameLabel.text = "Press SPACE to start";
#endif
        }

        private void Update()
        {
            HandleInputs();
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

            _startGameLabel.gameObject.SetActive(false);
            _playerMovement.enabled = true;

            _scoreManager.enabled = true;
            _runSpeedManager.enabled = true;
        }

        private void EndGame()
        {
        }
    }
}
