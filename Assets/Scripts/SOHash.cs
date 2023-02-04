using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.Rootdash.Data
{
    public class SOHash : ScriptableObject
    {
        [SerializeField] private string _hash;
        [SerializeField] private string _displayName;

        public string Hash => _hash;
        public string DisplayName => _displayName;
    }
}