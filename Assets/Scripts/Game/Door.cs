using com.maapiid.projectara.Core;
using UnityEngine;
using com.maapiid.projectara.Utils;

namespace com.maapiid.projectara.Game
{
    public class Door : MonoBehaviour
    {
        public Coords AccessToCoords { get; set; }
        
        private bool _areOpen;
        private bool _sleeping;
        private bool _actionsActive;
        
        [Header("Assets")]
        public SpriteRenderer doorSpriteR;
        
        
        private Color DEBUG_DoorSpriteColor;

        private void Start()
        {
            doorSpriteR = gameObject.GetComponent<SpriteRenderer>();
            DEBUG_DoorSpriteColor = doorSpriteR.color;
            
            _areOpen = false;
            _actionsActive = false;
        }


        private void MakeAction(int actionId)
        {
            _actionsActive = false;
            
            if (actionId == 1)
            {
                if (!_areOpen)
                {
                    _areOpen = true;
                    doorSpriteR.color = new Color(0, 1, 0, 0.5f);
                }
                else
                {
                    _areOpen = false;
                    doorSpriteR.color = DEBUG_DoorSpriteColor;
                }
            }

            if (actionId == 2)
            {
                if (!_areOpen)
                {
                    Debug.Log("Drzwi zamknięte!!!!");
                }
                else
                {
                    GameManager.Instance.gameEngine.LoadRoom(AccessToCoords);
                }
            }
        }
        
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _sleeping = false;
                _actionsActive = false;
            }
        }
        
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            
            if (Input.GetAxis("Submit") > 0 && !_sleeping)
            {
                Debug.Log("I pressed E > open action (1.open/close, 2. cross the door ?");

                _sleeping = true;
                _actionsActive = true;
            }

            // TODO: Action mechanism
            if (_actionsActive && _sleeping)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    MakeAction(1);
                }

                if (Input.GetKey(KeyCode.Alpha2))
                {
                    MakeAction(2);
                }
            }
        }
    }
}