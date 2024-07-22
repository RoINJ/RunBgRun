using UnityEngine;

namespace Scripts.Runner
{
    public class RunSpeedManager : MonoBehaviour
    {
        private const float Acceleration = 0.0001f;

        public float Speed { get; private set; }

        public void ResetSpeed()
        {
            Speed = Constants.StartMovementSpeed;
        }

        private void Start()
        {
            ResetSpeed();
        }

        private void FixedUpdate()
        {
            Speed += Acceleration;
        }
    }
}
