using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Scripts.Runner
{
    public class SectionPool : MonoBehaviour
    {
        private const int SectionCount = 5;

        private DiContainer _container;

        [SerializeField]
        private GameObject _sectionPrefab;

        private ObjectPool<GameObject> _sectionPool;

        public GameObject Get() => _sectionPool.Get();

        [Inject]
        public void Init(DiContainer container)
        {
            _container = container;
        }

        public void Release(GameObject section) => _sectionPool.Release(section);

        private void Awake()
        {
            _sectionPool = new ObjectPool<GameObject>(
                createFunc: () =>
                {
                    var section = _container.InstantiatePrefabForComponent<SectionMovement>(_sectionPrefab);
                    section.gameObject.SetActive(true);
                    return section.gameObject;
                },
                actionOnGet: section => section.SetActive(true),
                actionOnRelease: section => section.SetActive(false),
                actionOnDestroy: section => Destroy(section),
                defaultCapacity: SectionCount,
                maxSize: SectionCount
            );
        }
    }
}
