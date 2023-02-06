using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
    
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
