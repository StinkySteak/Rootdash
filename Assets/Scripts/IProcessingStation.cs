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
    }
}