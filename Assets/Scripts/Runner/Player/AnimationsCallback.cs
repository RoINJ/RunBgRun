using UnityEngine;

namespace Scripts.Runner.Player
{
    public class AnimationsCallback : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement _playerMovement;
        
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
