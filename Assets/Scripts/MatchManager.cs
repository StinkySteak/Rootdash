using Sirenix.OdinInspector;
using StinkySteak.Data;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Enum;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public class MatchManager : MonoBehaviour, IMatchManager
    {
        [SerializeField][ReadOnly] private MatchConfig _config;

        [Space]
        [SerializeField][ReadOnly] private MatchState _matchState;
        [SerializeField][ReadOnly] private float _timer;
        [SerializeField][ReadOnly] private float _initialDuration;

        public event System.Action OnMatchEnded;

        public void SetConfig(MatchConfig matchConfig)
            => _config = matchConfig;

        private void Start()
            => DependencyManager.Instance.MatchManager = this;

        private void Update()
        {
            ProcessTimer();
        }

        private void ProcessTimer()
        {
            if (_matchState != MatchState.InProgress) return;

            _timer -= Time.deltaTime;

            if (_timer <= 0)
                EndMatch();   
        }

        private void EndMatch()
        {
            _matchState = MatchState.Ending;
            OnMatchEnded?.Invoke();
        }

        public void StartMatch()
        {
            if (_matchState != MatchState.NotStarted) return;

            _matchState = MatchState.InProgress;
            _initialDuration = _config.Duration;
        }
    }
}