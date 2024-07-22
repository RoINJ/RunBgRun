using UnityEngine;
using Zenject;

namespace Scripts.Runner.Sections
{
    public class InitialSectionSpawner : MonoBehaviour
    {
        private SectionPool _sectionPool;

        [Inject]
        public void Init(SectionPool sectionPool)
        {
            _sectionPool = sectionPool;
        }

        private void Start()
        {
            for (var i = 0; i < Constants.ActiveSectionsCount; i++)
            {
                var section = _sectionPool.Get();
                section.GetComponent<SectionMovement>().enabled = false;
                section.transform.position = Vector3.forward * i * Constants.SectionLength;
            }
        }
    }
}
