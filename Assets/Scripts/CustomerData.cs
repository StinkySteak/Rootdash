using Sirenix.OdinInspector;
using StinkySteak.Rootdash.Data.Item;
using UnityEngine;

namespace StinkySteak.Rootdash.Data.Customer
{
    [CreateAssetMenu(fileName = "Customer Data", menuName = "Rootdash/Customer/Data")]
    public class CustomerData : SOHash
    {
        [SerializeField][PreviewField] private float _duration;
        [SerializeField][PreviewField] private Sprite _sprite;
        [SerializeField][PreviewField] private ItemData[] _requiredItems;

        public ItemData[] RequiredItems => _requiredItems;
        public float Duration => _duration;
    }
}