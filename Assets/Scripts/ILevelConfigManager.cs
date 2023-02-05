using StinkySteak.Data;

namespace StinkySteak.Rootdash.Manager
{
    public interface ILevelConfigManager
    {
        MatchConfig GetConfig(int level);
    }
}