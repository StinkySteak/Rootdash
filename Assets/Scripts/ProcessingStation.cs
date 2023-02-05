using Sirenix.OdinInspector;
using StinkySteak.Rootdash.Data.Item;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Interactable;
using StinkySteak.Rootdash.Manager;
using System;
using UnityEngine;

namespace StinkySteak.Rootdash.Station
{
    public class ProcessingStation : TickedBehaviour, IInteractable, IProcessingStation
    {
        [SerializeField] private string _name;

        [Space]
        [SerializeField] private float _processingDuration;
        [SerializeField] private ItemData _itemInput;
        [SerializeField] private ItemData _itemOutput;

        [Space]
        [SerializeField][ReadOnly] private bool _isReady;
        private bool _isProcessing => _processingTimer.IsRunning;

        private TickTimer _processingTimer;


        public int ItemInputId => _itemInput.Id;
        public string Name => _name;
        public bool IsReady => _isReady;
        public bool IsProcessing => _isProcessing;


        private IProcessingStationManager _manager;

        public event Action<ItemData> OnReady;
        public event Action OnCollected;

        private void Start()
        {
            _manager = DependencyManager.Instance.ProcessingStationManager;
            _manager.Register(this);
        }

        public void Interact()
            => _manager.Interact(this);

        private void Update()
        {
            if (_processingTimer.IsExpired(TickManager))
            {
                ProcessingDone();
                _processingTimer = TickTimer.None;
            }
        }

        private void ProcessingDone()
        {
            _isReady = true;
            OnReady?.Invoke(_itemOutput);
        }

        public bool TryCollect(out ItemData processedItem)
        {
            processedItem = null;
            if (!_isReady) return false;

            processedItem = _itemOutput;
            _isReady = false;

            print($"[ProcessingStation]: ({gameObject.name}) Sending Output {processedItem.Hash}");
            OnCollected?.Invoke();
            return true;
        }

        public bool TryProcess()
        {
            if (_isProcessing || _isReady) return false;

            print($"[ProcessingStation]: ({gameObject.name}) Processing...");

            _processingTimer = TickTimer.CreateFromSeconds(TickManager, _processingDuration);
            return true;
        }
    }
}