using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace com.maapiid.projectara.Mechanics
{
    [Serializable]
    public class InventorySystem
    {
        [SerializeField] private List<InventorySlot> _inventorySlots;

        public List<InventorySlot> InventorySlots => _inventorySlots;
        public int InventorySize => InventorySlots.Count;

        public UnityAction<InventorySlot> OnInventorySlotChanged;
        
        public InventorySystem(int size)
        {
            _inventorySlots = new List<InventorySlot>(size);

            for (int i = 0; i < size; i++)
            {
                _inventorySlots.Add(new InventorySlot());
            }
        }

        public bool AddToInventory(Item item, int amount)
        {
            _inventorySlots[0] = new InventorySlot(0, item, amount);
            return true;
        }
        
        public Item GetFromInventory(int slot, int amount)
        {
            return _inventorySlots[slot].ItemData;
        }
    }
}