using System;
using com.maapiid.projectara.Core;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace com.maapiid.projectara.Mechanics
{
    [RequireComponent((typeof(BoxCollider2D)))]
    public class ItemPickUp : MonoBehaviour
    {
        public float PickUpRadius = 1f;
        public Item ItemData;

        private SpriteRenderer spriteR;
        public BoxCollider2D myCollider;
        
        private void Awake()
        {
            myCollider = GetComponent<BoxCollider2D>();
            spriteR = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            spriteR.sprite = ItemData.icon;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("enter");
            var inventory = other.transform.GetComponent<InventoryHolder>();

            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
                GameManager.Instance.player.newInventorySystem.AddItem(ItemData, 10);
            }
           

            /*if (!inventory) return;

            if (inventory.InventorySystem.AddToInventory(ItemData, 1))
            {
                Destroy(this.gameObject);
            }*/
        }
    }
}