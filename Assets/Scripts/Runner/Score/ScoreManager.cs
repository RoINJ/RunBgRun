using TMPro;
using UnityEngine;

namespace Scripts.Runner.Score
{
    public class ScoreManager : MonoBehaviour
    {
        private const float DistanceRewardScore = 10f;

        [SerializeField]
        private TextMeshProUGUI _scoreLabel;

        private RunSpeedManager _runSpeedManager;

        private float _score;
        public int Score => (int)_score;

        private void Start()
        {
            _runSpeedManager = GetComponent<RunSpeedManager>();
        }

        private void Update()
        {
            AddScore(Time.deltaTime * _runSpeedManager.Speed * DistanceRewardScore);
        }

        private void AddScore(float score)
        {
            _score += score;
            _scoreLabel.text = Score.ToString();
        }
    }
}
