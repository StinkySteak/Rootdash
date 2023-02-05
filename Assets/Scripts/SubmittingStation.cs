using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Interactable;
using StinkySteak.Rootdash.Manager;
using UnityEngine;

namespace StinkySteak.Rootdash.Station
{
    public class SubmittingStation : MonoBehaviour, IInteractable, ISubmittingStation
    {
        [SerializeField] private string _name;

        public string Name => _name;

        private ISubmittingStationManager _manager;

        private void Start()
        {
            _manager = DependencyManager.Instance.SubmittingStationManager;
        }

        public void Interact()
        {
            _manager.Interact(this);
        }
    }
}