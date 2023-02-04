using UnityEngine;

namespace StinkySteak.Rootdash.Data.Customer
{
    [CreateAssetMenu(fileName = "Customer Data Container", menuName = "Rootdash/Customer/Container")]
    public class CustomerDataContainer : SOContainer<CustomerData>
    {
        public CustomerData Get(int id)
        {
            Debug.LogError($"[CustomerDataContainer]: Data not found: {id}");
            return null;
        }

        public CustomerData Get(string hash)
        {
            foreach (CustomerData data in _datas)
            {
                if(data.Hash == hash)
                    return data;
            }

            Debug.LogError($"[CustomerDataContainer]: Data not found: {hash}");
            return null;
        }
    }
}