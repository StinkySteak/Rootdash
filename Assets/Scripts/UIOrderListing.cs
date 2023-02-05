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
        [SerializeField] private UIImages[] _requirements;
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
                _image.sprite = _order.Customer.Sprite;

                // 0: Main Parent
                // 1: Icon Content

                _requirements[i].Images[0].gameObject.SetActive(true);
                _requirements[i].Images[1].sprite = _order.Customer.RequiredItems[i].Sprite;
            }
        }
    }
}