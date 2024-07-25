using Scripts.Runner.Sections.Obstacles;
using UnityEngine;

namespace Scripts.Runner.Sections
{
    public class SectionInitializer : MonoBehaviour
    {
        public void Initialize(Vector3 spawnPosition, bool startMovement = true)
        {
            transform.position = spawnPosition;
            GetComponent<SectionMovement>().enabled = startMovement;
            GetComponent<ObstaclesSpawner>().SpawnObstacles();
        }
    }
}
