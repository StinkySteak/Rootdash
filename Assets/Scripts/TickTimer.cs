using StinkySteak.Rootdash.Manager;
using UnityEngine;

namespace StinkySteak.Rootdash
{
    public struct TickTimer
    {
        public static TickTimer None => default;
        public bool IsRunning => Target > 0;
        public int Target { get; private set; }
        public int Initial { get; private set; }

        public static TickTimer CreateFromSeconds(ITickManager tickManager, float duration)
            => CreateFromTicks(tickManager, Mathf.RoundToInt(duration * tickManager.TickRate));

        public static TickTimer CreateFromTicks(ITickManager tickManager, int ticks)
        {
            int currentTick = tickManager.Tick;

            int targetTick = currentTick + ticks;

            return new TickTimer()
            {
                Target = targetTick,
                Initial = currentTick
            };
        }

        public bool IsExpired(ITickManager tickManager)
            => tickManager.Tick >= Target && Target > 0;

        public bool IsExpiredOrNotRunning(ITickManager tickManager)
            => tickManager.Tick >= Target;
    }
}