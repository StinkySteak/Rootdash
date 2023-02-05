using Sirenix.OdinInspector;
using StinkySteak.Data;
using StinkySteak.Rootdash.Dependency;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StinkySteak.Rootdash.Manager
{
    public class TickManager : MonoBehaviour, ITickManager
    {

        [SerializeField] private TickConfig _tickConfig;

        [SerializeField][ReadOnly] private List<TickedBehaviour> _behaviours = new();
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

                OnForwardTick();
            }
        }

        private void OnForwardTick()
        {
            for (int i = 0; i < _behaviours.Count; i++)
            {
                _behaviours[i].TickUpdate();
            }
        }

        public void Register(TickedBehaviour behaviour)
            => _behaviours.Add(behaviour);

        public void Unregister(TickedBehaviour behaviour)
            => _behaviours.Remove(behaviour);
    }
}