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

        public void SetActivePanel(EGameMenuState activePanel)
        {
            _mainMenuPanel.SetActive(activePanel == EGameMenuState.MainMenu);
            _scoreboardPanel.SetActive(activePanel == EGameMenuState.Scoreboard);
            _deathMenuPanel.SetActive(activePanel == EGameMenuState.DeathMenu);
            _inGamePanel.SetActive(activePanel == EGameMenuState.InGame);
        }

        public void ShowMainMenu() => SetActivePanel(EGameMenuState.MainMenu);
        
        public void ShowScoreboard() => SetActivePanel(EGameMenuState.Scoreboard);
    }
}
