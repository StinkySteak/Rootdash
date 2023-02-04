using StinkySteak.Rootdash.Data.Customer;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public class CustomerManager : MonoBehaviour, ICustomerManager
    {
        [SerializeField] private CustomerDataContainer _dataContainer;

        public CustomerData Get(int id) => _dataContainer.Get(id);
        public CustomerData Get(string hash) => _dataContainer.Get(hash);
    }
}