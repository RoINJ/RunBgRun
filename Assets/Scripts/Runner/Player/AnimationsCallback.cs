using UnityEngine;

namespace Scripts.Runner.Player
{
    public class AnimationsCallback : MonoBehaviour
    {
        private IMovementHandler _playerMovement;
        
        private void Start()
        {
            _playerMovement = GetComponentInParent<IMovementHandler>();
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
