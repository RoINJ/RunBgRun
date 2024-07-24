using Scripts.Runner.Sections.Obstacles;
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
            gameObject.GetComponentInParent<ObstaclesSpawner>().ReleaseObstacles();
            _sectionPool.Release(transform.parent.gameObject);
        }
    }
}
