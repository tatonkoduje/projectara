using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Game
{
    public class RoomView : MonoBehaviour
    {
        public Coords Coords { get; private set; }

        [Header ("Assets")]
        [SerializeField] private Sprite[] dangerNumberSprites;
        [SerializeField] private SpriteRenderer dangerNumberSpriteR;
        
        private Door[] _doors;

        private void Awake()
        {
            Debug.Log("Awake room view");
            _doors = GetComponentsInChildren<Door>();
        }
        
        
        public void PropagateCoords(Coords roomCoords, Dictionary<string, Coords> doorsCoords)
        {
            Debug.Log("PropagateCoords room view");
            Coords = roomCoords;
            foreach(var door in _doors)
            {
                door.AccessToCoords = doorsCoords[door.name];
                if (door.AccessToCoords.IsNull)
                {
                    door.gameObject.SetActive(false);
                }
            }
        }
        
        public void ChangeDangerNumber(int value)
        {
            dangerNumberSpriteR.sprite = value != -1 ? dangerNumberSprites[value] : null;
            
            // TODO: instancje drzwi jesli sa. Na kranch mapy ich nie ma? 
        }
    }
}