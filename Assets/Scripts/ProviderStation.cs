using StinkySteak.Rootdash.Data.Item;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Interactable;
using StinkySteak.Rootdash.Manager;
using UnityEngine;

namespace StinkySteak.Rootdash.Station
{
    public class ProviderStation : MonoBehaviour, IInteractable, IProviderStation
    {
        [SerializeField] private string _name;
        [SerializeField] private ItemData _providedItem;

        public string Name => _name;
        public ItemData ProvidedItem => _providedItem;

        private IProviderStationManager _manager;

        private void Start()
        {
            _manager = DependencyManager.Instance.ProviderStationManager;
            _manager.Register(this);
        }

        public void Interact()
            => _manager.Interact(this);
    }
}