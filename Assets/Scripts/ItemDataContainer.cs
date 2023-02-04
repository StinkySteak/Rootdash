using UnityEngine;

namespace StinkySteak.Rootdash.Data.Item
{
    [CreateAssetMenu(fileName = "Item Data Container", menuName = "Rootdash/Item/Container")]
    public class ItemDataContainer : SOContainer<ItemData>
    {
        public ItemData Get(int id)
        {
            Debug.LogError($"[CustomerDataContainer]: Data not found: {id}");
            return null;
        }

        public ItemData Get(string hash)
        {
            foreach (ItemData data in _datas)
            {
                if (data.Hash == hash)
                    return data;
            }

            Debug.LogError($"[CustomerDataContainer]: Data not found: {hash}");
            return null;
        }
    }
}