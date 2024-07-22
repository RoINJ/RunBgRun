using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Runner.Sections.Obstacles
{
    public class ObstaclesSpawner : MonoBehaviour
    {
        private const int SpawnInterval = 20;

        private ObstaclesPool _obstaclesPool;

        private List<KeyValuePair<int, GameObject>> _obstacles = new();

        [Inject]
        private void Init(ObstaclesPool obstaclesPool)
        {
            _obstaclesPool = obstaclesPool;
        }

        private void OnEnable()
        {
            //SpawnObstacles();
        }

        private void OnDisable()
        {
            //ReleaseObstacles();
        }

        public void SpawnObstacles()
        {
            for (int z = 0; z < Constants.SectionLength; z += SpawnInterval)
            {
                var obstacleType = Random.Range(0, _obstaclesPool.ObstaclesCount);
                var obstacle = _obstaclesPool.Get(obstacleType);

                obstacle.transform.SetParent(transform);

                var position = obstacle.transform.localPosition;
                position.z = z;
                obstacle.transform.localPosition = position;

                _obstacles.Add(new KeyValuePair<int, GameObject>(obstacleType, obstacle));
            }
        }

        public void ReleaseObstacles()
        {
            foreach (var obstacle in _obstacles)
            {
                _obstaclesPool.Release(obstacle.Key, obstacle.Value);
            }
        }
    }
}
