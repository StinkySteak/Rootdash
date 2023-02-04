using StinkySteak.Rootdash;
using UnityEngine;

namespace StinkySteak.Data
{
    [CreateAssetMenu(fileName = "Match Config", menuName = "Rootdash/Data/Match")]
    public class MatchConfig : ScriptableObject
    {
        [SerializeField] private float _duration;
        [SerializeField] private CutomerSpawning[] _customers;

        public float Duration => _duration;
        public CutomerSpawning[] Customers => _customers;
    }
}