using System;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public GameObject hud;
        public GameObject gameEngine;
        
        private static GameManager _instance;
    
        [Obsolete("Obsolete in Unity 2023.1.0b4")]
        public static GameManager Instance
        {
            get
            {
                if (_instance == null) _instance = GameObject.FindObjectOfType<GameManager>();
                return _instance;
            }
        }
    }
}
