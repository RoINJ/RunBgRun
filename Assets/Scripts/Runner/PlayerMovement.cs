using UnityEngine;

namespace Scripts.Runner
{
    public class PlayerMovement : MonoBehaviour
    {
        private float _movementSpeed;

        private void Start()
        {
            _movementSpeed = Constants.StartMovementSpeed;
        }

        private void FixedUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
