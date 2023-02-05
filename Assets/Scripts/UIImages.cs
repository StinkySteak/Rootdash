using UnityEngine;
using UnityEngine.UI;

namespace StinkySteak.Rootdash.UI.Listing
{
    public class UIImages : MonoBehaviour
    {
        [SerializeField] private Image[] _images;

        public Image[] Images => _images;
    }
}