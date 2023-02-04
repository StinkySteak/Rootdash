using StinkySteak.Rootdash.Data.Item;

namespace StinkySteak.Rootdash.Station
{
    public interface IProviderStation
    {
        ItemData ProvidedItem { get; }
    }
}