using StinkySteak.Rootdash.Data.Item;

namespace StinkySteak.Rootdash.Player
{
    public interface IPlayerItem
    {
        ItemData HeldItem { get; }
        void SetHeldItem(ItemData heldItem);
    }
}