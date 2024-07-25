using UnityEngine;

namespace Scripts.Runner.Player
{
    public class RespawnHelper : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        public void Respawn()
        {
            _playerMovement.Respawn();
        }
    }
}
