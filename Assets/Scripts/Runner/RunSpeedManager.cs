using UnityEngine;

namespace Scripts.Runner
{
    public class RunSpeedManager : MonoBehaviour
    {
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
            Speed += Constants.SpeedIncreasingAcceleration;
        }
    }
}
