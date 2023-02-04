using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public interface IPlayerCharacter
    {
        IPlayerInputProvider InputProvider { get; }
        IPlayerController Controller { get; }
        IPlayerInteraction Interact { get; }
        IPlayerItem Item { get; }
    }
}