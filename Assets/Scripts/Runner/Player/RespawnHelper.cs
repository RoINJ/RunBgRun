using UnityEngine;

namespace Scripts.Runner.Player
{
    public class RespawnHelper : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        public void Respawn()
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
            _animator.SetTrigger(Constants.Triggers.RunTrigger);
        }
    }
}
