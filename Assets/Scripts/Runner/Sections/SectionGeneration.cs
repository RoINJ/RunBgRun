using UnityEngine;
using Zenject;

namespace Scripts.Runner.Sections
{
    public class SectionGeneration : MonoBehaviour
    {
        private SectionPool _sectionPool;
        private GameConfiguration _gameConfiguration;

        private bool _wasRespawned;

        [Inject]
        private void Init(SectionPool sectionPool, GameConfiguration gameConfiguration)
        {
            _sectionPool = sectionPool;
            _gameConfiguration = gameConfiguration;
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
                var spawnPosition = transform.parent.position +
                    Vector3.forward * _gameConfiguration.SectionLength * _gameConfiguration.ActiveSectionsCount;

                section.GetComponent<SectionInitializer>().Initialize(spawnPosition);
            }
        }
    }
}
