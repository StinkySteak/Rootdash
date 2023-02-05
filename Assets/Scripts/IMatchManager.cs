using StinkySteak.Data;
using StinkySteak.Rootdash.Enum;
using System;

namespace StinkySteak.Rootdash.Manager
{
    public interface IMatchManager
    {
        void SetConfig(MatchConfig matchConfig);
        void StartMatch(float startDelay = 1);

        MatchConfig MatchConfig { get; }
        MatchState MatchState { get; }

        event Action<MatchState> OnMatchStateChanged;

        /// <summary>
        /// Determine Elapsed time during MatchStart
        /// </summary>
        float ElapsedTime { get; }
    }
}