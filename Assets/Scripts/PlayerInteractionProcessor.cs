using StinkySteak.Rootdash.Data.Item;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Manager;
using StinkySteak.Rootdash.Station;
using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerInteractionProcessor : MonoBehaviour, IPlayerComponent
    {
        private IProcessingStationManager _processingStationManager;
        private IProviderStationManager _providerStationManager;
        private ISubmittingStationManager _submittingStationManager;
        private IOrderProcessor _orderProcessor;
        private IPlayerCharacter _character;

        private IPlayerItem _playerItem => _character.Item;

        public void SetComponent(IPlayerCharacter character)
            => _character = character;


        private void Start()
        {
            _processingStationManager = DependencyManager.Instance.ProcessingStationManager;
            _providerStationManager = DependencyManager.Instance.ProviderStationManager;
            _submittingStationManager = DependencyManager.Instance.SubmittingStationManager;
            _orderProcessor = DependencyManager.Instance.CustomerProcessor;

            print($"Customer Processor: {_orderProcessor == null}");

            _processingStationManager.OnInteract += OnProcessingStationManager;
            _providerStationManager.OnInteract += OnProviderStationManager;
            _submittingStationManager.OnInteract += OnSubmitting;
        }

        private void OnSubmitting(ISubmittingStation station)
        {
            if (!_playerItem.IsHolding) return;

            if(_orderProcessor.TrySubmit(_playerItem.HeldItem))
                _playerItem.SetHeldItem(null);
        }

        private void OnProviderStationManager(IProviderStation station)
            => _playerItem.SetHeldItem(station.ProvidedItem);

        private void OnProcessingStationManager(IProcessingStation station)
        {
            if (TrySwapitem()) return;

            ProcessGenerally();

            void ProcessGenerally()
            {
                //Attempt to Collect
                if (!_playerItem.IsHolding)
                {
                    if (station.IsReady)
                    {
                        if (station.TryCollect(out ItemData itemData))
                        {
                            _playerItem.SetHeldItem(itemData);
                            return;
                        }
                    }
                }

                //Attempt to Process Item
                if (_playerItem.IsHolding && _playerItem.HeldItem.Id != station.ItemInputId)
                    return;

                if (!station.IsReady)
                {
                    if (station.TryProcess())
                        _playerItem.SetHeldItem(null);
                }
                else if (_playerItem == null)
                {
                    if (station.TryCollect(out ItemData itemData))
                        _playerItem.SetHeldItem(itemData);
                }
            }

            bool TrySwapitem()
            {
                bool canSwap =
                    _playerItem.IsHolding &&
                    _playerItem.HeldItem.Id == station.ItemInputId &&
                    station.IsReady;

                // If player is inteded to swap item to the processor
                // The player must have the same input item & the processor is ready
                if (_playerItem.HeldItem != null)
                {
                    if (canSwap)
                    {
                        //Steps:
                        // Collect Item & Store item temporarily
                        station.TryCollect(out ItemData itemOutput);

                        // Tell Station to start a new Process
                        station.TryProcess();

                        // Set the player's held item into the output
                        _playerItem.SetHeldItem(itemOutput, true);
                    }
                }

                return false;
            }
        }
    }
}