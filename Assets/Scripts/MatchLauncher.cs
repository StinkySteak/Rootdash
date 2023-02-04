using Sirenix.OdinInspector;
using StinkySteak.Data;
using UnityEngine;

namespace StinkySteak.Rootdash.Launcher
{
    public class MatchLauncher : GameLauncher
    {
        [SerializeField][AssetsOnly][PropertyOrder(-10)] protected MatchConfig _config;


        private void Awake()
        {
            SpawnDependencyManager();
            SpawnMatchManager();
            SpawnSystems();
            SpawnUIs();
        }

        private void Start()
        {
            StartGame(_config);
        }
    }
}