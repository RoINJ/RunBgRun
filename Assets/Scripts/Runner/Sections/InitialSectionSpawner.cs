using UnityEngine;
using Zenject;

namespace Scripts.Runner.Sections
{
    public class InitialSectionSpawner : MonoBehaviour
    {
        private SectionPool _sectionPool;

        [Inject]
        private void Init(SectionPool sectionPool)
        {
            _sectionPool = sectionPool;
        }

        private void Start()
        {
            for (var i = 1; i < Constants.ActiveSectionsCount; i++)
            {
                var section = _sectionPool.Get();
                section
                    .GetComponent<SectionInitializer>()
                    .Initialize(
                        Vector3.forward * i * Constants.SectionLength,
                        false);
            }
        }
    }
}
