using Sirenix.OdinInspector;
using UnityEngine;

namespace StinkySteak.Rootdash.Data.Item
{
    [CreateAssetMenu(fileName = "Item Data",menuName = "Rootdash/Item/Data")]
    public class ItemData : SOHash
    {
        [SerializeField][PreviewField] private Sprite _sprite;

        public Sprite Sprite => _sprite;
    }
}