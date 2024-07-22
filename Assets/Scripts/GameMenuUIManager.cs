using TMPro;
using UnityEngine;

namespace Scripts
{
    public class GameMenuUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _mainMenuPanel;

        [SerializeField]
        private GameObject _scoreboardPanel;

        [SerializeField]
        private GameObject _deathMenuPanel;

        [SerializeField]
        private GameObject _inGamePanel;

        [SerializeField]
        private TextMeshProUGUI _startGameLabel;

        private void Start()
        {
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

        public void ShowDeathPanel()
        {
            _mainMenuPanel.SetActive(false);
            _scoreboardPanel.SetActive(false);
            _deathMenuPanel.SetActive(true);
            _inGamePanel.SetActive(false);
        }

        public void ShowInGameMenu()
        {
            _mainMenuPanel.SetActive(false);
            _scoreboardPanel.SetActive(false);
            _deathMenuPanel.SetActive(false);
            _inGamePanel.SetActive(true);
        }
    }
}
