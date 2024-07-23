using Scripts.Authentication;
using Scripts.Runner.Score;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class ScoreSaver : MonoBehaviour
    {
        private ScoreManager _scoreManager;
        private IAuthenticationProvider _authenticationProvider;
        private IScoreStorage _scoreProvider;

        [Inject]
        private void Init(
            IAuthenticationProvider authenticationProvider,
            IScoreStorage scoreProvider)
        {
            _scoreManager = GetComponent<ScoreManager>();
            _authenticationProvider = authenticationProvider;
            _scoreProvider = scoreProvider;
        }

        public void SaveScore()
        {
            _scoreProvider.SaveScore(new ScoreEntity
            {
                Score = _scoreManager.Score,
                Username = _authenticationProvider.CurrentUser.Username,
            });
        }
    }
}
