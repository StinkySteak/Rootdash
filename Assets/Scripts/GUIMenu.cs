using StinkySteak.Rootdash.Loader;
using StinkySteak.Rootdash.UI.Listing;
using UnityEngine;
using UnityEngine.UI;

namespace StinkySteak.Rootdash.UI.GUI
{
    public class GUIMenu : MonoBehaviour
    {
        [Header("Story")]
        [SerializeField] private GameObject _storyPanel;
        [SerializeField] private Image _storyImage;
        [SerializeField] private Sprite[] _storySprites;
        [SerializeField] private Button _storyClickButton;
        private int _currentStory;

        [Space]
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private Button _playButton;

        [Header("Panel - Level Selection")]
        [SerializeField] private UIListing _levelSelectiionListingPrefab;
        [SerializeField] private Transform _levelSelectionListingSlot;

        private void Start()
        {
            AddListener();
        }

        private void AddListener()
        {
            _playButton.onClick.AddListener(() => StartStory());
            _storyClickButton.onClick.AddListener(() => OnStoryClicked());
        }

        private void StartStory()
        {
            _storyPanel.SetActive(true);
            _currentStory = 0;
        }

        private void OnStoryClicked()
        {
            _currentStory++;

            if (_currentStory >= _storySprites.Length - 1)
                CloseStory();

            _storyImage.sprite = _storySprites[_currentStory];
        }

        private void CloseStory()
        {
            _sceneLoader.LoadGameScene();
        }
    }
}