using Sirenix.OdinInspector;
using StinkySteak.Rootdash.Customer;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace StinkySteak.Rootdash.UI.Listing
{
    public class UIOrderListing : UIListing
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image[] _requirements;
        [SerializeField][ReadOnly] private ActiveOrder _order;

        private ITickManager _manager;

        private void Start()
        {
            _manager = DependencyManager.Instance.TickManager;
        }

        private void Update()
        {
            if (_order == null || _slider == null) return;

            _slider.value = _order.Timer.GetRemainingSeconds(_manager);
        }

        public void Set(ActiveOrder activeOrder)
        {
            _order = activeOrder;
            _slider.maxValue = _order.Customer.Duration;

            for (int i = 0; i < _order.Customer.RequiredItems.Length; i++)
            {
                _requirements[i].gameObject.SetActive(true);
                _requirements[i].sprite = _order.Customer.RequiredItems[i].Sprite;
            }
        }
    }
}