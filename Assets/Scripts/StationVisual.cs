using DG.Tweening;
using UnityEngine;

namespace StinkySteak.Rootdash.Station
{
    public class StationVisual : MonoBehaviour, IStationVisual
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private SpriteRenderer _iconRenderer;

        public void Show(bool enable)
            => _container.SetActive(enable);

        public void Set(Sprite sprite)
            => _iconRenderer.sprite = sprite;

        private IProcessingStation _station;

        private void Start()
        {
            _station = GetComponent<IProcessingStation>();
            _station.OnReady += Ready;
            _station.OnCollected += Collected;

            _container.transform.DOLocalMoveY(1.2f, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }

        private void Collected()
            => Show(false);

        private void Ready(Data.Item.ItemData obj)
        {
            Set(obj.Sprite);
            Show(true);
        }
    }
}