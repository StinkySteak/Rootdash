using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StinkySteak.Rootdash.UI.Listing {
    public class UIListing : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;

        public void SetTitle(string title)
            => _title.text = title;

        public void SetImage(Sprite sprite)
            => _image.sprite = sprite;
    }
}