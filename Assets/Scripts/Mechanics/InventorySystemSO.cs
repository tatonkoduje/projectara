using System.Collections.Generic;
using com.maapiid.savesystem;
using UnityEditor;
using UnityEngine;

namespace com.maapiid.projectara.Mechanics
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventorySystemSO : ScriptableObject, ISerializationCallbackReceiver
    {
        private Database database;
        public List<InventorySlot> Container = new List<InventorySlot>();

        private void OnEnable()
        {
#if UNITY_EDITOR
            database = (Database)AssetDatabase.LoadAssetAtPath("Assets/Resources/ItemDatabase.asset",
                typeof(Database));
#else
            database = Resources.Load<Database>("ItemDatabase");
#endif
        }

        
        public void AddItem(Item item, int amount)
        {
            Debug.Log("Add item");
            for (int i = 0; i < Container.Count; i++)
            {
                if (Container[i].ItemData == item)
                {
                    Container[i].AddToStack(amount);
                    return;
                }
            }
            Container.Add(new InventorySlot(database.GetId[item], item, amount));
        }

        public void Save()
        {
            string saved = JsonUtility.ToJson(this, true);
            SaveManagerComponent.NewSave(saved);
        }

        public void Load()
        {
            string loaded = SaveManagerComponent.NewLoad();
            JsonUtility.FromJsonOverwrite(loaded, this);
        }

        public void OnBeforeSerialize()
        {
           
        }

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < Container.Count; i++)
            {
                Container[i].ItemData = database.GetItem[Container[i].ID];
            }
        }
    }
}