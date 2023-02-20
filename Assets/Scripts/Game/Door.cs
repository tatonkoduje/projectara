using System;
using Core;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using Utils;

namespace Game
{
    public class Door : MonoBehaviour
    {
        private bool AreOpen { get; set; }
        public Coords AccessToCoords { get; set; }
        
        public SpriteRenderer doorSpriteR;

        private Color DEBUG_DoorSpriteColor;
        private bool _sleeping;
        private bool _actionsActive;

        private void Start()
        {
            doorSpriteR = gameObject.GetComponent<SpriteRenderer>();
            DEBUG_DoorSpriteColor = doorSpriteR.color;
            AreOpen = false;
            _actionsActive = false;
        }
        

        public void MakeAction(int actionId)
        {
            _actionsActive = false;
            
            if (actionId == 1)
            {
                if (!AreOpen)
                {
                    Debug.Log("Ktoś probuje otworzyć drzwi");
                    AreOpen = true;
                    Debug.Log("Drzwi otwarte: " + AreOpen);
                    doorSpriteR.color = new Color(0, 1, 0, 0.5f);
                }
                else
                {
                    Debug.Log("Ktoś probuje zamknac drzwi");
                    AreOpen = false;
                    Debug.Log("Drzwi otwarte: " + AreOpen);
                    doorSpriteR.color = DEBUG_DoorSpriteColor;
                }
            }

            if (actionId == 2)
            {
                if (!AreOpen)
                {
                    Debug.Log("Drzwi zamknięte!!!!");
                }
                else
                {
                    Debug.Log("Wchodze!!!!");
                    //gameObject.SendMessage("ChangeRoom", accessToCoords);
                    GameManager.Instance.gameEngine.LoadRoom(AccessToCoords);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Collision with Player detected - show 'E' letter");
            }
        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Collision with Player ended - hide 'E' letter");
                _sleeping = false;
                _actionsActive = false;
            }
        }
        
        private void OnTriggerStay2D(Collider2D col)
        {
            Debug.Log($"OnTriggerStay2D in Door (are open: {AreOpen}) with: {col.gameObject.tag} -> Press E to see actions" );
            Debug.Log("sleeping: "+ _sleeping + "  _actionsActive: " + _actionsActive);
            if (Input.GetAxis("Submit") > 0 && !_sleeping)
            {
                Debug.Log("I pressed E > open action (1.open/close, 2.unlock/lock, 3. cross the door ?");
                
                _sleeping = true;
                _actionsActive = true;
            }

            if (_actionsActive && _sleeping)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    Debug.Log("Action 1");
                    MakeAction(1);
                }

                if (Input.GetKey(KeyCode.Alpha2))
                {
                    
                    Debug.Log("Action 2");
                    MakeAction(2);
                }
            }
        }
    }
}