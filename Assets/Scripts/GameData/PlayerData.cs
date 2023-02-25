using System;
using com.maapiid.projectara.Core;
using com.maapiid.savesystem;
using UnityEngine;


namespace GameData
{
    [Serializable]
    public class PlayerData
    {
        public float Speed;
        public int xp;
        public float[] Position;

        public PlayerData(Player player)
        {
            Speed = player.speed;
            xp = player.xp;
            Position = new float[3];
            
            var position = player.transform.position;
            Position[0] = position.x;
            Position[1] = position.y;
            Position[2] = position.z;
        }
        
        public void Restore(MonoBehaviour mb_object)
        {
            var player = mb_object as Player;
            player.speed = Speed;
            player.xp = xp;
            player.transform.position = new Vector3(Position[0], Position[1], Position[2]);
        }
    }
}