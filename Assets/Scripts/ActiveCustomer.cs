using StinkySteak.Rootdash.Data.Customer;
using StinkySteak.Rootdash.Data.Item;
using StinkySteak.Rootdash.Manager;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StinkySteak.Rootdash.Customer
{
    [System.Serializable]
    public class ActiveOrder
    {
        [SerializeField] private CustomerData _customerData;
        [SerializeField] private List<ItemData> _remainingRequiredItems = new();
        [SerializeField] private int _tick;
        [SerializeField] private TickTimer _timer;

        public TickTimer Timer => _timer;
        public CustomerData Customer => _customerData;
        public IList<ItemData> RemainingRequiredItems => _remainingRequiredItems;

        public static ActiveOrder Create(CustomerData customerData, ITickManager tickManager)
        {
            return new ActiveOrder()
            {
                _customerData = customerData,
                _remainingRequiredItems = customerData.RequiredItems.ToList(),
                _tick = tickManager.Tick,
                _timer = TickTimer.CreateFromSeconds(tickManager, customerData.Duration)
            };
        }
    }
}