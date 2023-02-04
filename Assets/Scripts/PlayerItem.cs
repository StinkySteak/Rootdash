using Sirenix.OdinInspector;
using StinkySteak.Rootdash.Data.Item;
using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerItem : MonoBehaviour, IPlayerItem
    {
        [SerializeField][ReadOnly] private ItemData _heldItem;

        public ItemData HeldItem => _heldItem;

        public bool IsHolding => _heldItem != null;

        public void SetHeldItem(ItemData newItem, bool forceReplace = false)
        {
            if (IsHolding && newItem != null && !forceReplace)
            {
                Debug.LogWarning($"[PlayerItem]: Held Item Exist: {_heldItem.Hash}");
                return;
            }

            _heldItem = newItem;
        }
    }
}