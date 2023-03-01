using UnityEngine;

namespace com.maapiid.projectara.Mechanics
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public int Id { get; private set; }
        public int MaxStackSize { get; set; }

        public string itemName = "New Item";
        public string description = "Item description";
        public enum Type { Default, Consumable, Weapon, Ammunition, Diary, Tool }
        public Type type = Type.Default;

        public Sprite icon;
        

    }
}