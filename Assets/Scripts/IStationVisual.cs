using UnityEngine;

namespace StinkySteak.Rootdash.Station
{
    public interface IStationVisual
    {
        void Set(Sprite sprite);
        void Show(bool enable);
    }
}