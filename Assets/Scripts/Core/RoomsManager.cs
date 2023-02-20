using System.Collections.Generic;
using com.maapiid.projectara.Mechanics;
using UnityEngine;
using com.maapiid.projectara.Utils;

namespace com.maapiid.projectara.Core
{
    public class RoomsManager
    {
        public GameObject ActiveRoom { get; set; }

        private Sapper _sapper;
        private Coords _startRoomCoords;
        private Coords _activeRoomCoords;

        public void InitializeWorld(int dimension, int dangerCount)
        {
            Debug.Log("Initialize World");
            
            _sapper = new Sapper(dimension, dangerCount);
            // TODO: create all rooms with some dependency of Sapper
        }

        public Coords DrawStartRoom()
        {
            _startRoomCoords = _sapper.GetRandomCoordsWithoutBomb();
            _activeRoomCoords = _startRoomCoords;
            
            return _startRoomCoords;
        }

        public void MoveToRoom(Coords coords)
        {
            _activeRoomCoords = coords;
        }

        public int GetRoomDangerNumber()
        {
            return _sapper.GetInfo(GetRoomCoords());
        }
        
        public Coords GetRoomCoords()
        {
            return _activeRoomCoords;
        }

        public Dictionary<string, Coords> GetNeighborhoodCoords()
        {
            var dictionary = new Dictionary<string, Coords>
            {
                { "Top", CheckCoords(_activeRoomCoords.GetYPrevious()) },
                { "Bottom", CheckCoords(_activeRoomCoords.GetYNext()) },
                { "Left", CheckCoords(_activeRoomCoords.GetXPrevious()) },
                { "Right", CheckCoords(_activeRoomCoords.GetXNext()) }
            };

            return dictionary;
        }
        
        private Coords CheckCoords(Coords checkedCoords)
        {
            return _sapper.In2DArrayBounds(checkedCoords)
                ? checkedCoords
                : Coords.Empty();
        }
    }
}
