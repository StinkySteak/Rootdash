using Sirenix.OdinInspector;
using UnityEngine;

namespace StinkySteak.Rootdash.Data.Customer
{
    [CreateAssetMenu(fileName = "Customer Data", menuName = "Rootdash/Customer/Data")]
    public class CustomerData : SOHash
    {
        [SerializeField][PreviewField] private Sprite _sprite;
    }
}