using StinkySteak.Rootdash.Customer;
using StinkySteak.Rootdash.Data.Item;
using System.Collections.Generic;

namespace StinkySteak.Rootdash.Manager
{
    public interface IOrderProcessor
    {
        int CompletedOrder { get; }
        int FailedOrder { get; }


        IList<ActiveOrder> ActiveOrders { get; }

        bool TrySubmit(ItemData submittedItem);

        event System.Action OnOrderUpdated;
        event System.Action OnOrderFailed;

        /// <summary>
        /// Called upon all order is finihed
        /// </summary>
        event System.Action OnOrderClosed;
    }
}