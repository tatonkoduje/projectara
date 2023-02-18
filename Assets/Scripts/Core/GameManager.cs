using System;
using UI;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public HUD hud;
        public GameEngine gameEngine;
        
        private static GameManager _instance;
    
       
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }
        
        private void Start()
        {
            Debug.Log("Start GameManager");
            
            hud.ShowRoomCoords();
        }
    }
}
