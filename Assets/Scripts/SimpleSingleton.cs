using UnityEngine;

namespace StinkySteak.Rootdash.Util
{
    public class SimpleSingleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; protected set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = GetComponent<T>();
        }
    }
}