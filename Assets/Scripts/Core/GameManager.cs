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
            Debug.Log("Loading Game...");
            SaveManagerComponent.Load();
        }

        public void SaveGame()
        {
            Debug.Log("Saving Game...");
            SaveManagerComponent.Save();
        }
    }
}
