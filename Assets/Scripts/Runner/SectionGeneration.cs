using UnityEngine;

namespace Scripts.Runner
{
    public class SectionGeneration : MonoBehaviour
    {
        private const int SectionLength = 30;

        [SerializeField]
        private GameObject _sectionPrefab;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SpawnNewSection();
            }
        }

        private void SpawnNewSection()
        {
            Instantiate(_sectionPrefab, transform.parent.position + Vector3.forward * SectionLength, Quaternion.identity);
        }
    }
}
