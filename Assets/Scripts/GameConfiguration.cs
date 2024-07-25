using UnityEngine;

namespace Scripts
{
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "ScriptableObjects/GameConfiguration", order = 1)]
    public class GameConfiguration : ScriptableObject
    {
        public string AdUnitAndroidId = "ca-app-pub-3940256099942544/5224354917";

        public float StartMovementSpeed = 0.1f;
        public float SpeedIncreasingAcceleration = 0.00002f;
        public float SectionLength = 20f;
        public int ActiveSectionsCount = 10;
        public int ScoreboardLength = 25;

        
    }
}
