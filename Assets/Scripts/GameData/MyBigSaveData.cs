using System;
using com.maapiid.projectara.Utils;

namespace GameData
{
    [Serializable]
    public struct MyBigSaveData
    {
        public float playerSpeed;
        public int playerXp;
        public float[] playerPosition;

        public int coordsX;
        public int coordsY;

        public string somethingElse;
    }
}