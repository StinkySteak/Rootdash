using UnityEngine;

namespace StinkySteak.Rootdash.Player
{
    public class PlayerVisual : MonoBehaviour, IPlayerComponent
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private SpriteRenderer _heldItemRenderer;

        private IPlayerCharacter _character;

        private void Start() { }

        public void SetComponent(IPlayerCharacter character)
        {
            _character = character;

            GetComponent<IPlayerItem>().OnHeldItemSet += HeldItemSet;
        }

        private void HeldItemSet(Data.Item.ItemData obj)
        {
            bool isNull = obj == null;

            _container.SetActive(!isNull);

            if (isNull)
                return;

            _heldItemRenderer.sprite = obj.Sprite;
        }
    }
}