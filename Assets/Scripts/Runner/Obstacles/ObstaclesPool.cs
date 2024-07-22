using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

namespace Scripts.Runner.Obstacles
{
    public class ObstaclesPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _obstaclePrefabs;

        private ObjectPool<GameObject>[] _pools;

        public int ObstaclesCount => _pools.Length;
        
        public GameObject Get(int index) => _pools[index].Get();

        private void Start()
        {
            InitializePools();
        }

        private void InitializePools()
        {
            _pools = Enumerable
                .Range(0, _obstaclePrefabs.Length)
                .Select(CreatePool)
                .ToArray();
        }

        private ObjectPool<GameObject> CreatePool(int index) => new(
            createFunc: () => CreateObstacle(index),
            actionOnGet: section => section.SetActive(true),
            actionOnRelease: section => section.SetActive(false),
            actionOnDestroy: Destroy
        );

        private GameObject CreateObstacle(int index)
        {
            var obstacle = Instantiate(_obstaclePrefabs[index]);
            obstacle.gameObject.SetActive(true);
            return obstacle;
        }
    }
}
