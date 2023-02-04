using Sirenix.OdinInspector;
using StinkySteak.Rootdash.Data.Item;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Interactable;
using StinkySteak.Rootdash.Manager;
using UnityEngine;

namespace StinkySteak.Rootdash.Station
{
    public class ProcessingStation : MonoBehaviour, IInteractable, IProcessingStation
    {
        [SerializeField] private string _name;

        [Space]
        [SerializeField] private float _processingDuration;
        [SerializeField] private ItemData _itemInput;
        [SerializeField] private ItemData _itemOutput;

        [Space]
        [SerializeField][ReadOnly] private bool _isReady;
        [SerializeField][ReadOnly] private bool _isProcessing;

        private float _duration;


        public int ItemInputId => _itemInput.Id;
        public string Name => _name;
        public bool IsReady => _isReady;
        public bool IsProcessing => _isProcessing;


        private IProcessingStationManager _manager;

        public event System.Action OnProcessingDone;

        private void Start()
        {
            _manager = DependencyManager.Instance.ProcessingStationManager;
            _manager.Register(this);
        }

        public void Interact()
            => _manager.Interact(this);

        private void Update()
        {
            if (_isProcessing)
            {
                _duration -= Time.deltaTime;

                if (_duration <= 0)
                    ProcessingDone();
            }
        }

        private void ProcessingDone()
        {
            _isProcessing = false;
            _isReady = true;
            OnProcessingDone?.Invoke();
        }

        public bool TryCollect(out ItemData processedItem)
        {
            processedItem = null;
            if (!_isReady) return false;

            processedItem = _itemOutput;
            _isReady = false;

            print($"[ProcessingStation]: ({gameObject.name}) Sending Output {processedItem.Hash}");
            return true;
        }

        public bool TryProcess()
        {
            if (_isProcessing || _isReady) return false;

            print($"[ProcessingStation]: ({gameObject.name}) Processing...");

            _isProcessing = true;
            _duration = _processingDuration;
            return true;
        }
    }
}