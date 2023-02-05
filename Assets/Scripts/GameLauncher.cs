using Sirenix.OdinInspector;
using StinkySteak.Data;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Manager;
using StinkySteak.Rootdash.Util;
using UnityEngine;

namespace StinkySteak.Rootdash.Launcher
{
    public class GameLauncher : SimpleSingleton<GameLauncher>
    {
        [SerializeField][AssetsOnly] protected DependencyManager _dependencyManager;

        [Space]
        [SerializeField][AssetsOnly] protected TickManager _tickManager;
        [SerializeField][AssetsOnly] protected MatchManager _matchManager;

        [Space]
        [SerializeField][AssetsOnly] protected MonoBehaviour[] _systems;
        [SerializeField][AssetsOnly] protected MonoBehaviour[] _uis;

        private IMatchManager _activeMatchManager;

        protected void SpawnDependencyManager()
            => Instantiate(_dependencyManager);

        protected void SpawnTickManager()
            => Instantiate(_tickManager);

        protected void SpawnMatchManager()
            => _activeMatchManager = Instantiate(_matchManager);

        protected void StartGame(MatchConfig config, float delay = 1)
        {
            _activeMatchManager.SetConfig(config);
            _activeMatchManager.StartMatch(delay);
        }

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