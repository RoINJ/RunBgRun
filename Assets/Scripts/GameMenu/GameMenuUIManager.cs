using System;
using TMPro;
using UnityEngine;

namespace Scripts.GameMenu
{
    public class GameMenuUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameMenuPanel[] _panels;

        [SerializeField]
        private TextMeshProUGUI _startGameLabel;
        
        public void SetActivePanel(EGameMenuState activePanel)
        {
            Array.ForEach(_panels, p => p.gameObject.SetActive(p.MenuState == activePanel));
        }

        public void ShowMainMenu() => SetActivePanel(EGameMenuState.MainMenu);
        
        public void ShowScoreboard() => SetActivePanel(EGameMenuState.Scoreboard);
        
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
    }
}
