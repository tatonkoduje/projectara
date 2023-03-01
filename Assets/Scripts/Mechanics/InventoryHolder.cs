using System;
using UnityEngine;
using UnityEngine.Events;

namespace com.maapiid.projectara.Mechanics
{
    [Serializable]
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField] private int inventorySize;
        [SerializeField] protected InventorySystem _inventorySystem;

        public InventorySystem InventorySystem => _inventorySystem;
        
        public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

        private void Awake()
        {
            _inventorySystem = new InventorySystem(inventorySize);
        }
    }
}