using UnityEngine;

namespace Scripts.Runner
{
    public class AnimationsCallback : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        
        private void Start()
        {
            _playerMovement = GetComponentInParent<PlayerMovement>();
        }

        public void StopJumping()
        {
            _playerMovement.EndJump();
        }

        public void StopSliding()
        {
            _playerMovement.EndSlide();
        }
    }
}
