using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Station;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public class ProcessingStationManager : MonoBehaviour, IProcessingStationManager
    {
        private readonly List<IProcessingStation> _stations = new();

        public event System.Action<IProcessingStation> OnInteract;

        private void Start()
            => DependencyManager.Instance.ProcessingStationManager = this;

        public void Interact(IProcessingStation station)
            => OnInteract?.Invoke(station);

        public void Register(IProcessingStation station)
            => _stations.Add(station);
    }
}