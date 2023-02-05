using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public interface IPlayerController
    {
        Vector2 LastFacingDirection { get; }
        Vector2 Velocity { get; }
    }
}