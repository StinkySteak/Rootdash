using StinkySteak.Rootdash.Manager;
using StinkySteak.Rootdash.Util;

namespace StinkySteak.Rootdash.Dependency
{
    public class DependencyManager : MonoSingleton<DependencyManager>
    {
        public IProviderStationManager ProviderStationManager { get; set; }
        public IProcessingStationManager ProcessingStationManager { get; set; }
        public ISubmittingStationManager SubmittingStationManager { get; set; }
        public IMatchManager MatchManager { get; set; }
        public ITickManager TickManager { get; set; }
        public IOrderProcessor OrderProcessor { get; set; }
        public ILevelConfigManager LevelConfigManager { get; set; }
    }
}