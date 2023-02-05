using StinkySteak.Rootdash.Station;

namespace StinkySteak.Rootdash.Manager
{
    public interface ISubmittingStationManager
    {
        void Interact(ISubmittingStation station);

        event System.Action<ISubmittingStation> OnInteract;
    }
}