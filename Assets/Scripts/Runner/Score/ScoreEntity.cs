using System;

namespace Scripts.Runner.Score
{
    [Serializable]
    public record ScoreEntity
    {
        public string Username;
        
        public int Score;
    }
}
