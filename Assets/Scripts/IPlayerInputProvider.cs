using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public interface IPlayerInputProvider
    {
        PlayerInput.PlayerActions Input { get; }
    }
}