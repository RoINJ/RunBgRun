using UnityEngine;
using Zenject;

namespace Scripts.Runner.Sections
{
    public class InitialSectionSpawner : MonoBehaviour
    {
        private SectionPool _sectionPool;
        private GameConfiguration _gameConfiguration;

        [Inject]
        private void Init(SectionPool sectionPool, GameConfiguration gameConfiguration)
        {
            _sectionPool = sectionPool;
            _gameConfiguration = gameConfiguration;
        }

        private void Start()
        {
            for (var i = 1; i < _gameConfiguration.ActiveSectionsCount; i++)
            {
                var section = _sectionPool.Get();
                section
                    .GetComponent<SectionInitializer>()
                    .Initialize(
                        Vector3.forward * i * _gameConfiguration.SectionLength,
                        false);
            }
        }
    }
}
