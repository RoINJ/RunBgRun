using UnityEngine;

namespace Scripts
{
    public class GameSingleton<T> : MonoBehaviour where T : GameSingleton<T>
    {
        public static T Instance;

        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = (T) this;
                if (Application.isPlaying)
                    DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
