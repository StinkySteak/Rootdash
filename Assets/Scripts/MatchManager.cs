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
        [SerializeField][ReadOnly] private float _initialDuration;

        [SerializeField][ReadOnly] private int _remainingLife;

        public MatchConfig MatchConfig => _config;
        public MatchState MatchState => _matchState;

        public int RemainingLife => _remainingLife;

        public event Action<MatchState> OnMatchStateChanged;
        public event Action<bool> OnGameEnded;

        private TickTimer _startTimer;

        private IOrderProcessor _orderProcessor;

        public void SetConfig(MatchConfig matchConfig)
            => _config = matchConfig;

        protected override void Injected()
        {
            base.Injected();
            DependencyManager.Instance.MatchManager = this;
        }

        private void Start()
        {
            _orderProcessor = DependencyManager.Instance.OrderProcessor;
            _orderProcessor.OnOrderFailed += OrderFailed;
            _orderProcessor.OnOrderClosed += EndMatch;
        }

        private void OrderFailed()
        {
            _remainingLife--;

            if(_remainingLife <= 0 )
                EndMatch();
        }

        private void Update()
        {
            if (_startTimer.IsExpired(TickManager))
            {
                MatchStart();
                _startTimer = TickTimer.None;
            }
        }

        private void EndMatch()
        {
            if (_matchState == MatchState.Ending) return;

            bool isWinning = _remainingLife > 0;

            print($"[MatchManager]: Match Ended. Win: {isWinning}");

            _matchState = MatchState.Ending;
            OnMatchStateChanged?.Invoke(_matchState);
            OnGameEnded?.Invoke(isWinning);
        }

        public void StartMatch(float delay)
        {
            if (_matchState != MatchState.NotStarted) return;

            if (_startTimer.IsRunning) return;

            _remainingLife = _config.Life;
            _startTimer = TickTimer.CreateFromSeconds(TickManager, delay);
        }

        private void MatchStart()
        {
            _matchState = MatchState.InProgress;

            OnMatchStateChanged?.Invoke(MatchState);
        }
    }
}