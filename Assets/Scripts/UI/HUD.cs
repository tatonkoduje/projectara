using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text coordsTF_DEBUG;
        
        
        void Start()
        {
            Debug.Log("Start HUD");
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void ShowRoomCoords()
        {
            var t = GameManager.Instance.gameEngine.GetRoomCoords();
            coordsTF_DEBUG.SetText($"Room coordinates (x: {t.Item1}, y: {t.Item2})");
        }
    }
}
