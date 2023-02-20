using System;
using UI;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [Header ("References")]
        public HUD hud;
        public GameEngine gameEngine;
        public Player player;
        
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

        private void Awake()
        {
            Debug.Log("Awake GameManager");
        }

        private void Start()
        {
            Debug.Log("Start GameManager");
            
            hud.ShowRoomCoords();
        }
    }
}
