using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Manager;
using UnityEngine;

namespace StinkySteak.Rootdash
{
    public abstract class TickedBehaviour : MonoBehaviour
    {
        private ITickManager _tickManager;

        public ITickManager TickManager => _tickManager;

        public bool IsInitialized => _tickManager != null;

        private void Awake()
        {
            Injected();
        }

        protected virtual void Injected()
        {
            _tickManager = DependencyManager.Instance.TickManager;
        }
    }
}