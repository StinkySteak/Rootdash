using Sirenix.OdinInspector;
using StinkySteak.Data;
using StinkySteak.Rootdash.Dependency;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public class TickManager : MonoBehaviour, ITickManager
    {
        [SerializeField] private TickConfig _tickConfig;

        [SerializeField][ReadOnly] private int _tick;
        [SerializeField][ReadOnly] private float _rate;
        [SerializeField][ReadOnly] private float _elapsed;

        private float exceededTime;
        public int Tick => _tick;
        public float Rate => _rate;
        public int TickRate => _tickConfig.TickRate;

        private void Awake()
            => DependencyManager.Instance.TickManager = this;

        private void Start()
        {
            SetRate();
        }

        private void SetRate()
            => _rate = 1f / _tickConfig.TickRate;

        private void Update()
        {
            _elapsed += Time.deltaTime;

            if (_elapsed >= _rate)
            {
                exceededTime = _elapsed - _rate;
                
                _elapsed = 0 + exceededTime;

                _tick++;
            }
        }
    }
}