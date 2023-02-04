using Sirenix.OdinInspector;
using StinkySteak.Rootdash.Data.Item;
using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerItem : MonoBehaviour, IPlayerItem
    {
        [SerializeField][ReadOnly] private ItemData _heldItem;

        public ItemData HeldItem => _heldItem;

        public void SetHeldItem(ItemData heldItem)
        {
            if (heldItem != null)
            {
                Debug.LogWarning($"[PlayerItem]: Held Item Exist: {heldItem.Hash}");
                return;
            }

            _heldItem = heldItem;
        }
    }
}