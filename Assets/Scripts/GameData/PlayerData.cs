using System;
using com.maapiid.projectara.Core;
using UnityEngine;

namespace com.maapiid.projectara.GameData
{
    [Serializable]
    public struct PlayerData
    {
        public float speed;
        public int xp;
        public float[] position;
        
        public PlayerData Capture(Player player)
        {
            speed = player.speed;
            xp = player.xp;
            position = new float[3];
            
            var p = player.transform.position;
            position[0] = p.x;
            position[1] = p.y;
            position[2] = p.z;

            return this;
        }
        
        public void Restore(Player player)
        {
            player.speed = speed;
            player.xp = xp;
            player.transform.position = new Vector3(position[0], position[1], position[2]);
        }
    }
}