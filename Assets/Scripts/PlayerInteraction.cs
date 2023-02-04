using StinkySteak.Rootdash.Interactable;
using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerInteraction : MonoBehaviour, IPlayerInteraction, IPlayerComponent
    {
        private IPlayerCharacter _character;
        private IPlayerInputProvider _input => _character.InputProvider;

        [SerializeField] private Transform _interactPoint;
        [SerializeField] private float _interactDistance;
        [SerializeField] private LayerMask _interactableLayer;

        public void SetComponent(IPlayerCharacter character)
            => _character = character;

        private void Update()
        {
            if (_input.Input.Interact.IsPressed())
                Interact();
        }

        private void Interact()
        {
            Vector2 direction = _character.Controller.LastFacingDirection;

            _interactPoint.transform.rotation = Quaternion.LookRotation(direction, Vector2.up);

            RaycastHit2D hit =
                Physics2D.Raycast(_interactPoint.transform.position, _interactPoint.transform.forward, _interactDistance, _interactableLayer);

            if (hit)
            {
                if (hit.collider.transform.parent.TryGetComponent(out IInteractable interactable))
                {
                    print($"[PlayerInteraction]: Interact with: {interactable.Name}");

                    interactable.Interact();
                }
            }
        }
    }
}