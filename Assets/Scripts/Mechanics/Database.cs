using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.maapiid.projectara.Mechanics
{
    [CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Item Database")]
    public class Database : ScriptableObject, ISerializationCallbackReceiver
    {
        public Item[] items;
        public Dictionary<Item, int> GetId;
        public Dictionary<int, Item> GetItem;

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            GetId = new Dictionary<Item, int>();
            GetItem = new Dictionary<int, Item>();
            for (int i = 0; i < items.Length; i++)
            {
                GetId.Add(items[i], i);
                GetItem.Add(i, items[i]);
            }
        }
    }
}