using Sirenix.OdinInspector;
using StinkySteak.Data;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Enum;
using System;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public class MatchManager : TickedBehaviour, IMatchManager
    {
        [SerializeField][ReadOnly] private MatchConfig _config;

        [Space]
        [SerializeField][ReadOnly] private MatchState _matchState;
        [SerializeField][ReadOnly] private float _timer;
        [SerializeField][ReadOnly] private float _initialDuration;

        public MatchConfig MatchConfig => _config;
        public MatchState MatchState => _matchState;
        public float ElapsedTime => _timer;

        public event Action<MatchState> OnMatchStateChanged;

        private TickTimer _remainingTime;
        private TickTimer _startTimer;

        public void SetConfig(MatchConfig matchConfig)
            => _config = matchConfig;

        protected override void Injected()
        {
            base.Injected();
            DependencyManager.Instance.MatchManager = this;
        }

        private void Update()
        {
            if(_startTimer.IsExpired(TickManager))
            {
                MatchStart();
                _startTimer = TickTimer.None;
            }

            ProcessTimer();
        }

        private void ProcessTimer()
        {
            if (_matchState != MatchState.InProgress) return;

            if (_remainingTime.IsExpired(TickManager))
            {
                EndMatch();
                _remainingTime = TickTimer.None;
            }
        }

        private void EndMatch()
        {
            print($"[MatchManager]: Match Ended");

            _matchState = MatchState.Ending;
            OnMatchStateChanged?.Invoke(_matchState);
        }

        public void StartMatch(float delay)
        {
            if (_matchState != MatchState.NotStarted) return;

            if (_startTimer.IsRunning) return;

            _startTimer = TickTimer.CreateFromSeconds(TickManager, delay);
        }

        private void MatchStart()
        {
            _matchState = MatchState.InProgress;

            _initialDuration = _config.Duration;
            _remainingTime = TickTimer.CreateFromSeconds(TickManager, _initialDuration);

            OnMatchStateChanged?.Invoke(MatchState);
        }
    }
}