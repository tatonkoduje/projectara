using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text coordsTF_DEBUG;

        private bool showCoords;
        
        private void Awake()
        {
            Debug.Log("Awake HUD");
        }
        
        void Start()
        {
            Debug.Log("Start HUD");
        }

        void Update()
        {
            if (showCoords)
            {
                var coords = GameManager.Instance.gameEngine.GetRoomCoords();
                coordsTF_DEBUG.SetText($"Room coordinates (x: {coords.X}, y: {coords.Y})");
            }
        }
        

        public void ShowRoomCoords()
        {
            showCoords = true;
        }
    }
}
