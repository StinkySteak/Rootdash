using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerCharacter : MonoBehaviour, IPlayerCharacter
    {
        private IPlayerInputProvider _provider;
        private IPlayerController _controller;
        private IPlayerInteraction _interact;
        private IPlayerItem _item;

        public IPlayerInputProvider InputProvider => _provider;
        public IPlayerController Controller => _controller;
        public IPlayerInteraction Interact => _interact;

        public IPlayerItem Item => _item;

        private void Start()
        {
            CacheComponent();
        }

        private void CacheComponent()
        {
            IPlayerComponent[] components = GetComponents<IPlayerComponent>();

            foreach (IPlayerComponent component in components)
                component.SetComponent(this);

            _provider = GetComponent<IPlayerInputProvider>();
            _controller = GetComponent<IPlayerController>();
            _interact = GetComponent<IPlayerInteraction>();
            _item = GetComponent<IPlayerItem>();
        }
    }
}