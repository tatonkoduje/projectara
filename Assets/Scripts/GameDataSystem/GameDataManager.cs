using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using com.maapiid.projectara.Core;
using GameData;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace GameDataSystem
{
    public class GameDataManager
    {
        public static PlayerData Load()
        {
            string path = Application.persistentDataPath + "/playerData.aru";

            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = binaryFormatter.Deserialize(stream) as PlayerData;
                stream.Close();

                return data;
            }
            else
            {
                Debug.Log("Plik z savem nie istnieje");
                return null;
            }
        }

        public static void Save(Player player)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/playerData.aru";
            Debug.Log("sciezka -> " +  Application.persistentDataPath);
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(player);
            
            binaryFormatter.Serialize(stream, data);
            stream.Close();
        }
    }
}