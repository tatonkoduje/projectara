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

       
        private RoomsManager _roomsManager;
        
    
        private void Awake()
        {
            Debug.Log("Awake GameEngine");
            
            // create rooms world
            _roomsManager = new RoomsManager();
            _roomsManager.InitializeWorld(room2DSize, dangerRoomsCount);
            _roomsManager.DrawStartRoom();
        }

        private void Start()
        {
            Debug.Log("Start GameEngine");

            ShowRoom();
            // start player position in game - random coordinates
           
            
            
          
            
            // TODO: add listeners to doors
            // TODO: add script to doors with player collision detection
            // TODO: get info about new room
            // TODO: remove old and Instantiate new
            // TODO: think how to move that logic to room manager
            
            // TODO: extends room manager
            // TODO: in HUD read info from room manager by game engine access?  think about who manage everything
        }

        public Tuple<int, int> GetRoomCoords()
        {
            return _roomsManager.GetRoomCoords();
        }

        private void ShowRoom()
        {
            _roomsManager.ActiveRoom = Instantiate(roomPrefab, new Vector2(0, 0), Quaternion.identity);
            
            var infoNo = _roomsManager.GetRoomDangerNumber();
            _roomsManager.ActiveRoom.GetComponent<RoomView>().ChangeDangerNumber(infoNo);
        }
    }
}
