using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Manager;
using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerInteractionProcessor : MonoBehaviour, IPlayerComponent
    {
        private IProcessingStationManager _processingStationManager;
        private IProviderStationManager _providerStationManager;
        private IPlayerCharacter _character;

        private IPlayerItem _playerItem => _character.Item;

        public void SetComponent(IPlayerCharacter character)
            => _character = character;


        private void Start()
        {
            _processingStationManager = DependencyManager.Instance.ProcessingStationManager;
            _providerStationManager = DependencyManager.Instance.ProviderStationManager;

            _processingStationManager.OnInteract += OnProcessingStationManager;
            _providerStationManager.OnInteract += OnProviderStationManager;
        }

        private void OnProviderStationManager(Station.IProviderStation obj)
        {
            _playerItem.SetHeldItem(obj.ProvidedItem);
        }

        private void OnProcessingStationManager(Station.IProcessingStation obj)
        {
            
        }
    }
}