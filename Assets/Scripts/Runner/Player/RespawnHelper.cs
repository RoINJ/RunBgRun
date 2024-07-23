using UnityEngine;

namespace Scripts.Runner.Player
{
    public class RespawnHelper : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void Respawn()
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
            _animator.speed = 1f;
        }
    }
}
