using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Station;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public class ProviderStationManager : MonoBehaviour, IProviderStationManager
    {
        private List<IProviderStation> _stations = new();

        public event Action<IProviderStation> OnInteract;

        public void Interact(IProviderStation station)
            => OnInteract?.Invoke(station);

        public void Register(IProviderStation station)
            => _stations.Add(station);

        private void Start()
        {
            DependencyManager.Instance.ProviderStationManager = this;
        }
    }
}