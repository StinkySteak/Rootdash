using StinkySteak.Rootdash.Station;
using StinkySteak.Rootdash.Dependency;
using System;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public class SubmittingStationManager : MonoBehaviour, ISubmittingStationManager
    {
        public event Action<ISubmittingStation> OnInteract;

        public void Interact(ISubmittingStation station)
            => OnInteract?.Invoke(station);

        private void Awake()
            => DependencyManager.Instance.SubmittingStationManager = this;
    }
}