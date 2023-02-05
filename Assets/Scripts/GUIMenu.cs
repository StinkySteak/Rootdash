using StinkySteak.Rootdash.Loader;
using StinkySteak.Rootdash.UI.Listing;
using UnityEngine;
using UnityEngine.UI;

namespace StinkySteak.Rootdash.UI.GUI
{
    public class GUIMenu : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private Button _playButton;

        [Header("Panel - Level Selection")]
        [SerializeField] private UIListing _levelSelectiionListingPrefab;
        [SerializeField] private Transform _levelSelectionListingSlot;

        private void Start()
        {
            
        }

        private void AddListener()
        {
            _playButton.onClick.AddListener(() => _sceneLoader.LoadGameScene());
        }
    }
}