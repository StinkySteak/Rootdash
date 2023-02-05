using StinkySteak.Rootdash;
using UnityEngine;

namespace StinkySteak.Data
{
    [CreateAssetMenu(fileName = "Match Config", menuName = "Rootdash/Data/Match")]
    public class MatchConfig : ScriptableObject
    {
        [SerializeField] private int _life;
        [SerializeField] private CustomerSpawning[] _customers;

        public CustomerSpawning[] Customers => _customers;

        public int Life => _life;
    }
}