using com.maapiid.projectara.Core;
using TMPro;
using UnityEngine;

namespace com.maapiid.projectara.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text coordsTF_DEBUG;

        private bool _showCoords;
        
        private void Awake()
        {
            Debug.Log("Awake HUD");
        }

        private void Start()
        {
            Debug.Log("Start HUD");
        }

        private void Update()
        {
            if (_showCoords)
            {
                var coords = GameManager.Instance.gameEngine.GetRoomCoords();
                coordsTF_DEBUG.SetText($"Room coordinates (x: {coords.X}, y: {coords.Y})");
            }
        }
        
        public void ShowRoomCoords()
        {
            _showCoords = true;
        }
    }
}
