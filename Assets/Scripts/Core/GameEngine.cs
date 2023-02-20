using com.maapiid.projectara.Game;
using UnityEngine;
using com.maapiid.projectara.Utils;

namespace com.maapiid.projectara.Core
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
        }
        
        public void LoadRoom(Coords coords)
        {
            MovePlayer(coords);
                
            if (_roomsManager.ActiveRoom != null)
            {
                Destroy(_roomsManager.ActiveRoom);
            }
            
            _roomsManager.MoveToRoom(coords);
            
            _roomsManager.ActiveRoom = Instantiate(roomPrefab, new Vector2(0, 0), Quaternion.identity);
            var room =  _roomsManager.ActiveRoom.GetComponent<RoomView>();
            room.PropagateCoords(coords, _roomsManager.GetNeighborhoodCoords());
            room.ChangeDangerNumber( _roomsManager.GetRoomDangerNumber());
        }
        
        public Coords GetRoomCoords()
        {
            return _roomsManager.GetRoomCoords();
        }

        
        /*
        * Direction logic is temporary - create better logic.... 
        */
        private void MovePlayer(Coords coords)
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
        }
    }
}
