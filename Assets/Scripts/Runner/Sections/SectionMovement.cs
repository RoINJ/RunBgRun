using UnityEngine;

namespace Scripts.Runner.Sections
{
    public class SectionMovement : MonoBehaviour
    {
        private float _movementSpeed;

        private void Start()
        {
            _movementSpeed = Constants.StartMovementSpeed;
        }

        private void FixedUpdate()
        {
            transform.position += Vector3.back * _movementSpeed;
        }
    }
}
