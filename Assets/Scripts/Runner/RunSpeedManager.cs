using UnityEngine;
using Zenject;

namespace Scripts.Runner
{
    public class RunSpeedManager : MonoBehaviour
    {
        private GameConfiguration _gameConfiguration;

        public float Speed { get; private set; }

        public void ResetSpeed()
        {
            Speed = _gameConfiguration.StartMovementSpeed;
        }

        [Inject]
        private void Init(GameConfiguration gameConfiguration)
        {
            _gameConfiguration = gameConfiguration;
        }

        private void Start()
        {
            ResetSpeed();
        }

        private void FixedUpdate()
        {
            Speed += _gameConfiguration.SpeedIncreasingAcceleration;
        }
    }
}
