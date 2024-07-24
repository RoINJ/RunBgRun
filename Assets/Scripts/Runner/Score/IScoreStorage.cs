using System;
using System.Collections.Generic;

namespace Scripts.Runner.Score
{
    public interface IScoreStorage
    {
        void SaveScore(ScoreEntity score);
        void GetTopScores(Action<IReadOnlyList<ScoreEntity>> resultCallback);
    }
}