using Sirenix.OdinInspector;
using StinkySteak.Rootdash.Data.Item;
using UnityEngine;

namespace StinkySteak.Rootdash.Data.Customer
{
    [CreateAssetMenu(fileName = "Customer Data", menuName = "Rootdash/Customer/Data")]
    public class CustomerData : SOHash
    {
        [SerializeField] private float _duration;
        [SerializeField] private ItemData[] _requiredItems;

        [Space]
        [SerializeField][PreviewField] private Sprite _sprite;

        public ItemData[] RequiredItems => _requiredItems;
        public float Duration => _duration;
        public Sprite Sprite => _sprite;
    }
}