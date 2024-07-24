using UnityEngine;

namespace Scripts.Runner.Sections.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField]
        private EObstacleType _obstacleType;

        public EObstacleType ObstacleType => _obstacleType;
    }
}
