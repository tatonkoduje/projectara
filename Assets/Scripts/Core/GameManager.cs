using System;
using System.Collections;
using System.Collections.Generic;
using com.maapiid.projectara.UI;
using com.maapiid.projectara.Utils;
using com.maapiid.savesystem;
using GameData;
using NUnit.Framework;
using UnityEngine;

namespace com.maapiid.projectara.Core
{
    public class GameManager : MonoBehaviour
    {
        [Header ("References")]
        public HUD hud;
        public GameEngine gameEngine;
        public Player player;

        private GameDataManager _gameDataManager;
        
        private void Awake()
        {
            Debug.Log("Awake GameManager");
            _gameDataManager = new GameDataManager();
        }

        private void Start()
        {
            Debug.Log("Start GameManager");
           
            
            
            hud.ShowRoomCoords();
        }
        
        public void LoadGame()
        {
            Debug.Log("Loading Game...");
            // load player from default file
           // PlayerData data = GameDataManager.Load() as PlayerData;
           // PlayerData data = _gameDataManager.LoadFrom("myFilePlayer") as PlayerData;
            
           /*player.speed = data.Speed;
           player.transform.position = new Vector3(
               data.Position[0],
               data.Position[1], 
               data.Position[2]);*/
           
            List<string> keys = new List<string>() {"myPlayer1", "coordsy1", "coordsy2"}; 
            Dictionary<string, ISavableData> datas = _gameDataManager.LoadFrom(keys);
            
            PlayerData pdata = datas["myPlayer1"] as PlayerData;
            
            player.speed = pdata.Speed;
            player.transform.position = new Vector3(
                pdata.Position[0],
                pdata.Position[1], 
                pdata.Position[2]);
            
            CoordsData cdata = datas["coordsy1"] as CoordsData;
            CoordsData cdat2 = datas["coordsy2"] as CoordsData;

            Debug.Log("coordsy1" + cdata.Y);
            Debug.Log("coordsy2" + cdat2.Y);
        }

        public void SaveGame()
        {
            Debug.Log("Saving Game...");
            PlayerData data = new PlayerData(player);
            CoordsData coordsData = new CoordsData(new Coords(1, 2));
            CoordsData coordsData2 = new CoordsData(new Coords(10, 20));
            List<ISavableData> listOfData = new List<ISavableData>() { data, coordsData, coordsData2};
            
            // saving player data in default file
           // GameDataManager.Save(data); // <- Save() always save in the same file and overwrite old data
           // GameDataManager.SaveTo(data, "myFilePlayer"); // <- save to specific file
           // _gameDataManager.Save(listOfData); // <- saveuje to w plikach w jakims folderze

           Dictionary<string, ISavableData> datas = new Dictionary<string, ISavableData>();
           datas.Add("myPlayer1", data);
           datas.Add("coordsy1", coordsData);
           datas.Add("coordsy2", coordsData2);
           
           _gameDataManager.SaveTo(datas);
            
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
