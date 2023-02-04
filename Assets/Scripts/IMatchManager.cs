using StinkySteak.Data;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public interface IMatchManager
    {
        void SetConfig(MatchConfig matchConfig);
        void StartMatch();
    }
}