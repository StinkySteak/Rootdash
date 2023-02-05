using StinkySteak.Rootdash.Customer;
using StinkySteak.Rootdash.Dependency;
using StinkySteak.Rootdash.Manager;
using StinkySteak.Rootdash.UI.Listing;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace StinkySteak.Rootdash.UI.GUI
{
    public class GUIGame : MonoBehaviour
    {
        [Header("UI Endgame")]
        [SerializeField] private GameObject _panelEndgame;
        [SerializeField] private GameObject _storyFinal;
        [SerializeField] private TMP_Text _endGameText;
        [SerializeField] private Color32 _winColor;
        [SerializeField] private Color32 _loseColor;

        [Header("UI Score")]
        [SerializeField] private TMP_Text _lifeText;

        [Header("UI Active Orders")]
        [SerializeField] private Transform _orderListingSlot;
        [SerializeField] private UIOrderListing _orderListingprefab;

        private List<UIOrderListing> _listings = new();

        private IOrderProcessor _orderProcessor;
        private IMatchManager _matchManager;

        private void Start()
        {
            _orderProcessor = DependencyManager.Instance.OrderProcessor;
            _orderProcessor.OnOrderUpdated += UpdateOrder;

            _matchManager = DependencyManager.Instance.MatchManager;
            _matchManager.OnGameEnded += GameEnded;
        }

        private void GameEnded(bool isWinning)
        {
            _panelEndgame.SetActive(true);
            string text = isWinning ? "YOU WON" : "YOU LOST";
            Color32 textColor = isWinning ? _winColor : _loseColor;

            _storyFinal.SetActive(isWinning);

            _endGameText.text = text;
            _endGameText.color = textColor;
        }

        private void Update()
        {
            _lifeText.text = $"{_matchManager.RemainingLife}";
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