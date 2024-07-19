using UnityEngine;
using Zenject;

namespace Scripts.Runner.Sections
{
    public class SectionGeneration : MonoBehaviour
    {
        private SectionPool _sectionPool;

        [Inject]
        public void Init(SectionPool sectionPool)
        {
            _sectionPool = sectionPool;
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
            var section = _sectionPool.Get();
            section.transform.position = transform.parent.position + Vector3.forward * Constants.SectionLength * Constants.ActiveSectionsCount;
        }
    }
}
