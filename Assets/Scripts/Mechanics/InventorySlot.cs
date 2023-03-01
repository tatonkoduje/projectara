using System;
using UnityEngine;

namespace com.maapiid.projectara.Mechanics
{
    [Serializable]
    public class InventorySlot
    {
        public int ID;
        
        [SerializeField] private Item itemData;
        [SerializeField] private int stackSize;

        public Item ItemData
        {
            get => itemData;
            set => itemData = value;
        }

        public int StackSize => stackSize;

        public InventorySlot(int id, Item source, int amount)
        {
            ID = id;
            itemData = source;
            stackSize = amount;
        }

        public InventorySlot()
        {
            ClearSlot();
        }

        public void ClearSlot()
        {
            itemData = null;
            stackSize = -1;
        }

        public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
        {
            amountRemaining = ItemData.MaxStackSize - stackSize;

            return RoomLeftInStack(amountToAdd);
        }

        public bool RoomLeftInStack(int amountToAdd)
        {
            if (stackSize + amountToAdd <= itemData.MaxStackSize) return true;
            else return false;
        }

        public void AddToStack(int amount)
        {
            stackSize += 1;
        }

        public void RemoveFromStack(int amount)
        {
            stackSize -= 1;
        }
    }
}