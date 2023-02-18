using System;
using Mechanics;
using UnityEngine;

namespace Core
{
    public class RoomsManager
    {
        public GameObject ActiveRoom { get; set; }

        private Sapper _sapper;
        private Tuple<int, int> _startRoomCoords;
        private Tuple<int, int> _activeRoomCoords;
        
        public RoomsManager()
        {
            
        }

        public void InitializeWorld(int dimension, int dangerCount)
        {
            Debug.Log("Initialize World");
            
            _sapper = new Sapper(dimension, dangerCount);
            // TODO: create all rooms with some dependency of Sapper
        }

        public Tuple<int, int> DrawStartRoom()
        {
            _startRoomCoords = _sapper.GetRandomCoordsWithoutBomb();
            _activeRoomCoords = _startRoomCoords;
            
            
            
            return _startRoomCoords;
        }

        public int GetRoomDangerNumber()
        {
            var infoNo = _sapper.GetInfo(GetRoomCoords());
            Debug.Log("infoNo: " + infoNo);

            return infoNo;
        }
        
        public Tuple<int, int> GetRoomCoords()
        {
            return _activeRoomCoords;
        }
    }
}
