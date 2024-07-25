using UnityEngine;
using Zenject;

namespace Scripts.Runner.Sections.Obstacles
{
    public class ObstaclesSpawner : MonoBehaviour
    {
        private ObstaclesPool _obstaclesPool;

        private int _obstacleType;
        private GameObject _obstacle;

        public void SpawnObstacles()
        {
            var obstacleType = Random.Range(0, _obstaclesPool.ObstaclesCount);
            _obstacle = _obstaclesPool.Get(obstacleType);

            _obstacle.transform.SetParent(transform);

            var position = _obstacle.transform.localPosition;
            position.z = 0;
            _obstacle.transform.localPosition = position;
        }

        public void ReleaseObstacles()
        {
            if (_obstacle is not null)
            {
                _obstacle.transform.SetParent(null);
                _obstaclesPool.Release(_obstacleType, _obstacle);
            }
        }

        [Inject]
        private void Init(ObstaclesPool obstaclesPool)
        {
            _obstaclesPool = obstaclesPool;
        }
    }
}
