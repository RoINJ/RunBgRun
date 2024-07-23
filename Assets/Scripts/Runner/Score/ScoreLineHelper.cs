using Scripts.Runner.Score;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class ScoreLineHelper : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _usernameLabel;

        [SerializeField]
        private TextMeshProUGUI _scoreLabel;

        public void SetScore(int number, string username, int score)
        {
            _usernameLabel.text = $"{number}. {username}";
            _scoreLabel.text = score.ToString();
        }
    }
}
