using StinkySteak.Rootdash.Data.Customer;
using UnityEngine;

namespace StinkySteak.Rootdash
{
    [System.Serializable]
    public class CutomerSpawning
    {
        [SerializeField] private float _spawnDelay;
        [SerializeField] private CustomerData _customer;

        public float SpawnDelay => _spawnDelay;
        public CustomerData CustomerData => _customer;
    }
}