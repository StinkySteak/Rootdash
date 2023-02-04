using StinkySteak.Rootdash.Station;

namespace StinkySteak.Rootdash.Manager
{
    public interface IProcessingStationManager
    {
        void Interact(IProcessingStation station);
        void Register(IProcessingStation station);

        event System.Action<IProcessingStation> OnInteract;
    }
}