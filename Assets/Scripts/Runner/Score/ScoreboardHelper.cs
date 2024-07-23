using System.Collections.Generic;
using System.Linq;
using Scripts.Runner.Score;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class ScoreboardHelper : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _scrollViewContent;

        [SerializeField]
        private GameObject _scorePrefab;

        private IScoreStorage _scoreStorage;

        [Inject]
        private void Init(IScoreStorage scoreStorage)
        {
            _scoreStorage = scoreStorage;
        }

        private void OnEnable()
        {
            GetTopScores();
        }

        private void OnDisable()
        {
            ClearScoreboard();
        }

        private void GetTopScores()
        {
            _scoreStorage.GetTopScores(ShowScoreboard);
        }

        private void ClearScoreboard()
        {
            for (int i = 0; i < _scrollViewContent.transform.childCount; i++)
            {
                Destroy(_scrollViewContent.transform.GetChild(i).gameObject);
            }
        }

        private void ShowScoreboard(IReadOnlyList<ScoreEntity> scores)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                var scoreItem = Instantiate(_scorePrefab, _scrollViewContent);
                scoreItem.GetComponent<ScoreLineHelper>().SetScore(i + 1, scores[i].Username, scores[i].Score);
            }
        }
    }
}
