using StinkySteak.Rootdash.Data.Item;

namespace StinkySteak.Rootdash.Station
{
    public interface IProcessingStation
    {
        int ItemInputId { get; }

        bool IsReady { get; }
        bool IsProcessing { get; }

        bool TryProcess();
        bool TryCollect(out ItemData itemOutput);


        /// <summary>
        /// returns Item output
        /// </summary>
        event System.Action<ItemData> OnReady;

        /// <summary>
        /// Called upon the ready Item is taken by the player
        /// </summary>
        event System.Action OnCollected;
    }
}