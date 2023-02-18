using System;
using Game;
using Mechanics;
using UI;
using UnityEngine;

namespace Core
{
    public class GameEngine : MonoBehaviour
    {
        // world settings
        public int room2DSize;
        public int dangerRoomsCount;
        //
        
        public GameObject roomPrefab;
        private GameObject _room;
        
        private RoomsManager _roomsManager;
        private Sapper _sapper;
        
    
        private void Awake()
        {
            // create rooms world
            _roomsManager = new RoomsManager();
            _sapper = new Sapper(room2DSize, dangerRoomsCount);
           
        }

        private void Start()
        {
            _roomsManager.ActiveRoom = Instantiate(roomPrefab, new Vector2(0, 0), Quaternion.identity);
            
            var infoNo = _sapper.GetInfo(Tuple.Create<int, int>(0, 0));
            Debug.Log("infoNo: " + infoNo);
            
            //GetComponentInParent<HUD>().showRoomCoords(); //info from RoomsManager
            
            _roomsManager.ActiveRoom.GetComponent<RoomView>().ChangeDangerNumber(infoNo);
            // TODO: add listeners to doors
            // TODO: add script to doors with player collision detection
            // TODO: get info about new room
            // TODO: remove old and Instantiate new
            // TODO: think how to move that logic to room manager
            
            // TODO: add coors label to HUD
            // TODO: extends room manager
            // TODO: in HUD read info from room manager by game engine access?  think about who manage everything
        }
    }
}
