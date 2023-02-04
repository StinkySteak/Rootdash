using StinkySteak.Rootdash.Data.Item;
using UnityEngine;

namespace StinkySteak.Rootdash.Manager
{
    public class ItemManager : MonoBehaviour, IItemManager
    {
        [SerializeField] private ItemDataContainer _dataContainer;
    }
}