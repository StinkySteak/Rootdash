using StinkySteak.Rootdash.Station;

namespace StinkySteak.Rootdash.Manager
{
    public interface IProviderStationManager
    {
        void Interact(IProviderStation station);
        void Register(IProviderStation station);

        event System.Action<IProviderStation> OnInteract;
    }
}