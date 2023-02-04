using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerInputProvider : MonoBehaviour, IPlayerInputProvider
    {
        private PlayerInput _playerInput;

        public PlayerInput.PlayerActions Input => _playerInput.Player;

        private void Start()
        {
            _playerInput = new();
            _playerInput.Enable();
        }

        private void OnDisable()
            => _playerInput.Disable();

        private void OnEnable()
        {
            if (_playerInput != null)
                _playerInput.Enable();
        }
    }
}