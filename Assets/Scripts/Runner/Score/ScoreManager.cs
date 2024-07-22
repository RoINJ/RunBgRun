using TMPro;
using UnityEngine;

namespace Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreLabel;

        private int _score;
        public int Score => _score;

        public void SetScore(int score)
        {
            _score = score;
            _scoreLabel.text = _score.ToString();
        }

        private void Start()
        {
            SetScore(0);
        }
    }
}
