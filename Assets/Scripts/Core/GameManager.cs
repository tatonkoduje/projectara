using com.maapiid.projectara.Mechanics;
using com.maapiid.projectara.UI;
using com.maapiid.projectara.Utils;
using com.maapiid.savesystem;
using UnityEngine;

namespace com.maapiid.projectara.Core
{
    public class GameManager : UnitySingleton<GameManager>
    {
        [Header ("References")]
        public HUD hud;
        public GameEngine gameEngine;
        public Player player;

        private Item item;
        
        private void Awake()
        {
            Debug.Log("Awake GameManager");
        }

        private void Start()
        {
            Debug.Log("Start GameManager");

            if (Messanger.Msg == "continue")
            {
                SaveManagerComponent.Load();
            }
            
            hud.ShowRoomCoords();
        }
        
        public void LoadGame()
        {
            /*var state = SaveManagerComponent.NewLoad();
            Debug.Log("item loaded: " + state);
            JsonUtility.FromJsonOverwrite(state, item);*/
           
            player.newInventorySystem.Load();
            
            Debug.Log("Loading Game...");
            SaveManagerComponent.Load();
        }

        public void SaveGame()
        {
            /*item = player.GetComponent<InventoryHolder>().InventorySystem.GetFromInventory(0, 1);
            var json = JsonUtility.ToJson(item);
            SaveManagerComponent.NewSave(json);*/
            
            player.newInventorySystem.Save();
            
            Debug.Log("Saving Game...");
            SaveManagerComponent.Save();
        }
    }
}
