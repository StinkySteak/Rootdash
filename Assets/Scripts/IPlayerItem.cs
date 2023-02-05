using StinkySteak.Rootdash.Data.Item;

namespace StinkySteak.Rootdash.Player
{
    public interface IPlayerItem
    {
        bool IsHolding { get; }
        ItemData HeldItem { get; }
        void SetHeldItem(ItemData heldItem, bool forceReplace = false);
        event System.Action<ItemData> OnHeldItemSet;
    }
}