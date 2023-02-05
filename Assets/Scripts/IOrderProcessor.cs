using StinkySteak.Rootdash.Customer;
using StinkySteak.Rootdash.Data.Item;
using System.Collections.Generic;

namespace StinkySteak.Rootdash.Manager
{
    public interface IOrderProcessor
    {
        IList<ActiveOrder> ActiveOrders { get; }

        bool TrySubmit(ItemData submittedItem);

        event System.Action OnOrderUpdated;
    }
}