using UnityEngine;
using Zenject;

namespace Scripts.Runner.Sections
{
    public class SectionRemoval : MonoBehaviour
    {
        private SectionPool _sectionPool;

        [Inject]
        private void Init(SectionPool sectionPool)
        {
            _sectionPool = sectionPool;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                DestroySection();
            }
        }

        private void DestroySection()
        {
            _sectionPool.Release(transform.parent.gameObject);
            //Destroy(transform.parent.gameObject);
        }
    }
}
