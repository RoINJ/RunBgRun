using System;
using Scripts.Runner.Player;
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

        private void Start()
        {
            _playerMovement.enabled = false;
            SetStartGameLabel();
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
            _startGameLabel.gameObject.SetActive(false);
            _playerMovement.enabled = true;

            var sections = FindObjectsOfType<SectionMovement>();
            Array.ForEach(sections, s => s.enabled = true);
        }
    }
}
