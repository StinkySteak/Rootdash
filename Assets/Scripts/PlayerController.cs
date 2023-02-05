using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerController : MonoBehaviour, IPlayerComponent, IPlayerController
    {
        private Rigidbody2D _rigidbody;

        [SerializeField] private float _moveSpeed;

        private IPlayerInputProvider _inputProvider => _character.InputProvider;

        private IPlayerCharacter _character;
        private Vector2 _lastFacingDirection;
        public Vector2 LastFacingDirection => _lastFacingDirection;

        public Vector2 Velocity => _rigidbody.velocity;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetComponent(IPlayerCharacter component)
           => _character = component;

        private void FixedUpdate()
        {
            Vector2 input = _inputProvider.Input.Move.ReadValue<Vector2>();
            Vector2 velocity = _moveSpeed * Time.deltaTime * input;

            ProcessMove(velocity);
        }

        private void ProcessMove(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;

            if (velocity.magnitude > 0)
                _lastFacingDirection = _rigidbody.velocity.normalized;
        }
    }
}