using StinkySteak.Rootdash.Manager;
using StinkySteak.Rootdash.Util;

namespace StinkySteak.Rootdash.Dependency
{
    public class DependencyManager : MonoSingleton<DependencyManager>
    {
        public IProviderStationManager ProviderStationManager { get; set; }
        public IProcessingStationManager ProcessingStationManager { get; set; }
    }
}