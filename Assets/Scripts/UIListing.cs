using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StinkySteak.Rootdash.UI.Listing {
    public class UIListing : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _title;
        [SerializeField] protected Button _button;
        [SerializeField] protected Image _image;

        public void SetTitle(string title)
            => _title.text = title;

        public void SetImage(Sprite sprite)
            => _image.sprite = sprite;
    }
}