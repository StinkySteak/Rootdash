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


        public string Name => _name;

        private IProcessingStationManager _manager;

        private void Start()
            => _manager = DependencyManager.Instance.ProcessingStationManager;

        public void Interact()
        {
            _manager.Interact(this);
        }

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
            _isProcessing = true;
        }

        public void Process()
        {
            if (_isProcessing || _isReady) return;

            _duration = _processingDuration;
        }
    }
}