using Scripts.Runner.Sections.Obstacles;
using UnityEngine;
using Zenject;

namespace Scripts.Runner.Sections
{
    public class SectionGeneration : MonoBehaviour
    {
        private SectionPool _sectionPool;

        private bool _wasRespawned;

        [Inject]
        private void Init(SectionPool sectionPool)
        {
            _sectionPool = sectionPool;
        }

        private void OnDisable()
        {
            _wasRespawned = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SpawnNewSection();
            }
        }

        private void SpawnNewSection()
        {
            if (!_wasRespawned)
            {
                _wasRespawned = true;

                var section = _sectionPool.Get();
                section.transform.position = transform.parent.position +
                    Vector3.forward * Constants.SectionLength * Constants.ActiveSectionsCount;

                section.GetComponentInParent<ObstaclesSpawner>().SpawnObstacles();
            }
        }
    }
}
