using StinkySteak.Rootdash.Util;
using UnityEngine;

namespace StinkySteak.Rootdash.Launcher
{
    public class GameLauncher : SimpleSingleton<GameLauncher>
    {
        [SerializeField] protected MonoBehaviour[] _systems;
        [SerializeField] protected MonoBehaviour[] _uis;

        protected void SpawnSystems()
        {
            foreach (MonoBehaviour system in _systems)
                Instantiate(system);
        }
        protected void SpawnUIs()
        {
            foreach (MonoBehaviour ui in _uis)
                Instantiate(ui);
        }
    }
}