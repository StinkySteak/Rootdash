using Sirenix.OdinInspector;
using StinkySteak.Rootdash.Data.Item;
using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerItem : MonoBehaviour, IPlayerItem, IPlayerComponent
    {
        [SerializeField][ReadOnly] private ItemData _heldItem;

        public ItemData HeldItem => _heldItem;
        private IPlayerCharacter _character;
        private IPlayerInputProvider _input => _character.InputProvider;
        public event System.Action<ItemData> OnHeldItemSet;
        public bool IsHolding => _heldItem != null;

        private void Update()
        {
            if (_input.Input.Trash.IsPressed())
                TrashItem();
        }

        private void TrashItem()
        {
            if (_heldItem == null) return;

            print($"[PlayerItem]: Item Trashed: {_heldItem}");
            SetHeldItem(null);
        }

        public void SetHeldItem(ItemData newItem, bool forceReplace = false)
        {
            if (IsHolding && newItem != null && !forceReplace)
            {
                Debug.LogWarning($"[PlayerItem]: Held Item Exist: {_heldItem.Hash}");
                return;
            }

            OnHeldItemSet?.Invoke(newItem);
            _heldItem = newItem;
        }

        public void SetComponent(IPlayerCharacter character)
            => _character = character;
    }
}