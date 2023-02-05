using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.Data
{
    [CreateAssetMenu(fileName = "Tick Config",menuName = "Rootdash/Tick Config")]
    public class TickConfig : ScriptableObject
    {
        [SerializeField] private int _tickrate = 60;

        public int TickRate => _tickrate;
    }
}