using UnityEngine;

namespace Scripts.Runner.Player
{
    public class DeathManager : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                Debug.Log("Player is dead");
            }
        }
    }
}
