using UnityEngine;

namespace Scripts.Runner.Sections
{
    public class SectionMovement : MonoBehaviour
    {
        private RunSpeedManager _runSpeedManager;

        private void Start()
        {
            _runSpeedManager = FindObjectOfType<RunSpeedManager>();
        }

        private void FixedUpdate()
        {
            transform.position += Vector3.back * _runSpeedManager.Speed;
        }
    }
}
