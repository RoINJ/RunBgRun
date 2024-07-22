using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

namespace Scripts.Runner.Sections.Obstacles
{
    public class ObstaclesPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _obstaclePrefabs;

        private ObjectPool<GameObject>[] _pools;

        public int ObstaclesCount => _pools.Length;
        
        public GameObject Get(int index) => _pools[index].Get();

        public void Release(int index, GameObject gameObject) => _pools[index].Release(gameObject);

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
            actionOnGet: obstacle => obstacle.SetActive(true),
            actionOnRelease: obstacle => obstacle.SetActive(false),
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
