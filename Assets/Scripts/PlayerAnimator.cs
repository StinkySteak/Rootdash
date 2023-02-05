using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerAnimator : MonoBehaviour, IPlayerComponent
    {
        [SerializeField] private Animator _animator;

        private IPlayerCharacter _character;
        private IPlayerController _controller => _character.Controller;

        public void SetComponent(IPlayerCharacter character)
            => _character = character;

        private void Update()
        {
            _animator.SetBool("IsWalking", _controller.Velocity.magnitude > 1);
            _animator.SetFloat("Horizontal", _controller.LastFacingDirection.x);
            _animator.SetFloat("Vertical", _controller.LastFacingDirection.y);
        }
    }
}