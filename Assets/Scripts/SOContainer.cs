using UnityEngine;

namespace StinkySteak.Rootdash.Data
{
    public class SOContainer<T> : ScriptableObject
    {
        [SerializeField] protected T[] _datas;

        public T[] Datas => _datas;
    }
}