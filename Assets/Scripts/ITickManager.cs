using StinkySteak.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public interface ITickManager
    {
        int Tick { get; }
        float Rate { get; }
        int TickRate { get; }

        void Register(TickedBehaviour behaviour);
        void Unregister(TickedBehaviour behaviour);

        event System.Action OnTick;
    }
}