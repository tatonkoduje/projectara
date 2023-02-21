using System;
using com.maapiid.projectara.UI;
using GameData;
using GameDataSystem;
using UnityEngine;

namespace com.maapiid.projectara.Core
{
    public class GameManager : MonoBehaviour
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
            
            hud.ShowRoomCoords();
        }
        
        public void LoadGame()
        {
            Debug.Log("Loading Game...");
            PlayerData data = GameDataManager.Load();
            player.speed = data.Speed;
            player.transform.position = new Vector3(
                data.Position[0],
                data.Position[1], 
                data.Position[2]);
        }

        public void SaveGame()
        {
            Debug.Log("Saving Game...");
            GameDataManager.Save(player);
        }
        
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }
    }
}
