using StinkySteak.Rootdash.Customer;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Manager;
using StinkySteak.Rootdash.UI.Listing;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.Rootdash.UI.GUI
{
    public class GUIGame : MonoBehaviour
    {
        [Header("UI Order")]
        [SerializeField] private Transform _orderListingSlot;
        [SerializeField] private UIOrderListing _orderListingprefab;

        private List<UIOrderListing> _listings = new();

        private IOrderProcessor _orderProcessor;

        private void Start()
        {
            _orderProcessor = DependencyManager.Instance.OrderProcessor;
            _orderProcessor.OnOrderUpdated += UpdateOrder;
        }

        private void UpdateOrder()
        {
            ClearListings();
            
            for (int i = 0; i < _orderProcessor.ActiveOrders.Count; i++)
            {
                ActiveOrder order = _orderProcessor.ActiveOrders[i];

                UIOrderListing listing = Instantiate(_orderListingprefab, _orderListingSlot);
                listing.Set(order);
                _listings.Add(listing);
            }
        }
        private void ClearListings()
        {
            foreach (var listing in _listings)
                Destroy(listing.gameObject);

            _listings.Clear();
        }
    }
}