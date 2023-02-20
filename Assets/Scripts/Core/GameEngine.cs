using System;
using Game;
using Mechanics;
using UI;
using UnityEngine;
using Utils;

namespace Core
{
    public class GameEngine : MonoBehaviour
    {
        [Header ("Inventory")]
        public int room2DSize;
        public int dangerRoomsCount;
        
        [Header ("Assets")]
        public GameObject roomPrefab;

       
        private RoomsManager _roomsManager;
        
    
        private void Awake()
        {
            Debug.Log("Awake GameEngine");
            
            // create rooms world
            _roomsManager = new RoomsManager();
            _roomsManager.InitializeWorld(room2DSize, dangerRoomsCount);
           
        }

        private void Start()
        {
            Debug.Log("Start GameEngine");

            LoadRoom(_roomsManager.DrawStartRoom());
            // start player position in game - random coordinates
           
            
            
          
            
            // TODO: add listeners to doors - DONE
            // TODO: add script to doors with player collision detection - DONE
            // TODO: get info about new room
            // TODO: remove old and Instantiate new
            // TODO: think how to move that logic to room manager
            
            // TODO: extends room manager
            // TODO: in HUD read info from room manager by game engine access?  think about who manage everything
        }


        /*
         * Direction logic is temporary - create better logic.... 
         */
        public void LoadRoom(Coords coords)
        {
            if (coords.X > _roomsManager.GetRoomCoords().X)
            {
                GameManager.Instance.player.transform.position = new Vector3(-1.6f, -0.63f, 0);
            }
            if (coords.X < _roomsManager.GetRoomCoords().X)
            {
                GameManager.Instance.player.transform.position = new Vector3(10.6f, -0.63f, 0);
            }
            if (coords.Y < _roomsManager.GetRoomCoords().Y)
            {
                GameManager.Instance.player.transform.position = new Vector3(4.5f, -5.9f, 0);
            }
            if (coords.Y > _roomsManager.GetRoomCoords().Y)
            {
                GameManager.Instance.player.transform.position = new Vector3(4.5f, 5.4f, 0);
            }
            
            
     
            Debug.Log($"Request to GameEngine - ktos chce przejsc do pokoju Coords -> x:{coords.X},y:{coords.Y}");

            if (_roomsManager.ActiveRoom != null)
            {
                Destroy(_roomsManager.ActiveRoom);
            }
            
            
            _roomsManager.MoveToRoom(coords);
            _roomsManager.ActiveRoom = Instantiate(roomPrefab, new Vector2(0, 0), Quaternion.identity);
            
            
            var room =  _roomsManager.ActiveRoom.GetComponent<RoomView>();
            room.PropagateCoords(coords, _roomsManager.GetNeighborhoodCoords());
           _roomsManager.ActiveRoom.GetComponent<RoomView>().ChangeDangerNumber( _roomsManager.GetRoomDangerNumber());


           
        }
        
        
        public Coords GetRoomCoords()
        {
            return _roomsManager.GetRoomCoords();
        }
    }
}
