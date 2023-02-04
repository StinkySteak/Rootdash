using UnityEngine;

namespace StinkySteak.Rootdash.Data
{
    public class SOHash : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _hash;
        [SerializeField] private string _displayName;

        public int Id => _id;
        public string Hash => _hash;
        public string DisplayName => _displayName;
    }
}