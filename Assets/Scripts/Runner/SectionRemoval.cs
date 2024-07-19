using UnityEngine;

namespace Scripts.Runner
{
    public class SectionRemoval : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                DestroySection();
            }
        }

        private void DestroySection()
        {
            Debug.Log("Destroy section");
            Destroy(transform.parent.gameObject);
        }
    }
}
