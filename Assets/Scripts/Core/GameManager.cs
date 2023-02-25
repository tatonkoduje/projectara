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

        //private SaveManager _saveManager;
        
        // save example
        public MyBigSaveData MyBigSaveData;
        
        private void Awake()
        {
            Debug.Log("Awake GameManager");
           // _saveManager = new SaveManager();
            MyBigSaveData = new MyBigSaveData();
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
            /*
            Dictionary<string, ISavableData> datas = _saveManager.LoadFrom(keys);
            
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
            */
            
            
            // example 3
            //MyBigSaveData mybigdata = Load();

            
            var data = SaveManager.Load();
            var playerData = SaveManager.Load()["abcd"] as PlayerData;
            playerData.Restore(player);
            
        }

        public void SaveGame()
        {
            Debug.Log("Saving Game...");
            PlayerData data = new PlayerData(player);
            CoordsData coordsData = new CoordsData(new Coords(1, 2));
            CoordsData coordsData2 = new CoordsData(new Coords(10, 20));
            List<object> listOfData = new List<object>() { data, coordsData, coordsData2};
            
            // saving player data in default file
           // GameDataManager.Save(data); // <- Save() always save in the same file and overwrite old data
           // GameDataManager.SaveTo(data, "myFilePlayer"); // <- save to specific file
           // _gameDataManager.Save(listOfData); // <- saveuje to w plikach w jakims folderze

           Dictionary<string, object> datas = new Dictionary<string, object>();
           datas.Add("abcd", data);
           datas.Add("coordsy1", coordsData);
           datas.Add("coordsy2", coordsData2);
           
           // example 3 --------------------------------------------------------
           /*MyBigSaveData.playerSpeed = player.speed;
           MyBigSaveData.playerXp = player.xp;
            
           var position = gameObject.transform.position;
           MyBigSaveData.playerPosition[0] = position.x;
           MyBigSaveData.playerPosition[1] = position.y;
           MyBigSaveData.playerPosition[2] = position.z;

           MyBigSaveData.coordsX = new Coords(1, 2).X;
           MyBigSaveData.coordsX = new Coords(1, 2).Y;*/

           // This method looking for all SavableEntity components and saves all ISavable MonoBehaviour scripts data to one binary file.
           // SaveManager.Instance.Initialize();
           //SaveManagerComponent.Save();
          // SaveManager.Instance.Init();
           SaveManager.Save(datas);
           
           //MyBigSaveData.somethingElse = dostep do obiektu i zczytuje dane
           // ...

           //_saveManager.SaveTo(datas);

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
