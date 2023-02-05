using StinkySteak.Data;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Util;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public class LevelConfigManager : MonoSingleton<LevelConfigManager>, ILevelConfigManager
    {
        [SerializeField] private MatchConfig[] _configs;

        private void Start()
        {
            DependencyManager.Instance.LevelConfigManager = this;
        }

        public MatchConfig GetConfig(int level)
            => _configs[level - 1];
    }
}