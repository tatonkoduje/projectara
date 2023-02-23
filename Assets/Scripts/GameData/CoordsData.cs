using com.maapiid.projectara.Utils;
using com.maapiid.savesystem;
using UnityEngine;

namespace GameData
{
    [System.Serializable]
    public class CoordsData : ISavableData
    {
        public int X;
        public int Y;
        
        public CoordsData(Coords coords)
        {
            X = coords.X;
            Y = coords.Y;
        }
        
        public void Restore(MonoBehaviour mb_object)
        {
            throw new System.NotImplementedException();
        }
    }
}