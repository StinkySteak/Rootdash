using Sirenix.OdinInspector;
using StinkySteak.Rootdash.Customer;
using StinkySteak.Rootdash.Data.Item;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Enum;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    /// <summary>
    /// This Behaviour is responsible for Handling Adding and Removing Customer
    /// </summary>
    public class OrderProcessor : TickedBehaviour, IOrderProcessor
    {
        [SerializeField][ReadOnly] private int _activeCustomerIndex = -1;
        [SerializeField]
        [ReadOnly] private List<ActiveOrder> _activeOrders = new();

        private TickTimer _addCustomerTimer;

        private IMatchManager _matchManager;

        public IList<ActiveOrder> ActiveOrders => _activeOrders.AsReadOnly();

        private CustomerSpawning[] _customerSpawning => _matchManager.MatchConfig.Customers;

        private int _completedOrder;
        private int _failedOrder;

        public int CompletedOrder => _completedOrder;
        public int FailedOrder => _failedOrder;

        public event Action<ActiveOrder> OnOrderCompleted;
        public event Action OnOrderUpdated;
        public event Action OnOrderFailed;
        public event Action OnOrderClosed;

        protected override void Injected()
        {
            base.Injected();
            _matchManager = DependencyManager.Instance.MatchManager;
            _matchManager.OnMatchStateChanged += MatchStateChanged;
            DependencyManager.Instance.OrderProcessor = this;
        }

        private void MatchStateChanged(MatchState state)
        {
            if (state == MatchState.InProgress)
            {
                StartProcess();
            }
        }

        public bool TrySubmit(ItemData submittedItem)
        {
            if (TryGetIndex(submittedItem, out int index))
            {
                SubmitItemTo(submittedItem, index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove Customer by Submitting Item
        /// </summary>
        private void SubmitItemTo(ItemData itemData, int index)
        {
            _activeOrders[index].RemainingRequiredItems.Remove(itemData);

            if (_activeOrders[index].RemainingRequiredItems.Count <= 0)
            {
                OnOrderCompleted?.Invoke(_activeOrders[index]);
                _completedOrder++;

                print($"[CustomerProcessor]: Order Completed: {_activeOrders[index].Customer.Hash}");

                _activeOrders.RemoveAt(index);
                CheckRemainingCustomer();
                OnOrderUpdated?.Invoke();
            }
        }

        private void CheckRemainingCustomer()
        {
            if (IsNextInexist())
            {
                OnOrderClosed?.Invoke();
                return;
            }
        }

        private bool TryGetIndex(ItemData item, out int index)
        {
            for (int i = 0; i < _activeOrders.Count; i++)
            {
                foreach (ItemData requiredItem in _activeOrders[i].RemainingRequiredItems)
                {
                    if (requiredItem.Id == item.Id)
                    {
                        index = i;
                        return true;
                    }
                }
            }

            index = -1;
            return false;
        }


        public override void TickUpdate()
        {
            AddCustomer();
            RemoveCustomer();
        }

        /// <summary>
        /// Remove Customer by Lifetime
        /// </summary>
        private void RemoveCustomer()
        {
            for (int i = 0; i < _activeOrders.Count; i++)
            {
                ActiveOrder order = _activeOrders[i];

                if (order.Timer.IsExpiredOrNotRunning(TickManager))
                {
                    print($"[OrderProcessor]: Failed Customer: {order.Customer.Hash}");

                    _failedOrder++;
                    _activeOrders.RemoveAt(i);
                    OnOrderFailed?.Invoke();
                    CheckRemainingCustomer();
                    OnOrderUpdated?.Invoke();
                }
            }
        }

        private void StartProcess()
        {
            float customerSpawnDelay = _matchManager.MatchConfig.Customers[_activeCustomerIndex + 1].SpawnDelay;

            _addCustomerTimer = TickTimer.CreateFromSeconds(TickManager, customerSpawnDelay);
        }

        private void AddCustomer()
        {
            if (_matchManager.MatchState != MatchState.InProgress) return;

            if (_addCustomerTimer.IsExpiredOrNotRunning(TickManager))
            {
                //check if there is the next customer
                if (IsNextInexist())
                    return;

                print($"[CustomerProcessor]: Customer Added: Index: {_activeCustomerIndex + 1}");

                //add next
                _activeOrders.Add(ActiveOrder.Create(_customerSpawning[_activeCustomerIndex + 1].CustomerData, TickManager));
                _activeCustomerIndex++;
                OnOrderUpdated?.Invoke();

                if (IsNextInexist())
                    return;

                _addCustomerTimer = TickTimer.CreateFromSeconds(TickManager, _customerSpawning[_activeCustomerIndex + 1].SpawnDelay);
            }


        }
        private bool IsNextInexist()
                => _activeCustomerIndex >= _customerSpawning.Length - 1;
    }
}