using System;
using UnityEngine;

namespace Core
{
    public class Player : MonoBehaviour
    {
        public float speed;
        
        private Vector2 _movement = new Vector2();
        private Rigidbody2D _rb2d;

    
        private void Start()
        {
            //this.name = ""
            _rb2d = GetComponent<Rigidbody2D>();
        }


        // Update is called once per frame
        private void Update()
        {
            /*if (Input.GetAxis("Submit") > 0)
            {
                Debug.Log("I pressed E in Player Update()" ); 
            }*/
        }

        private void FixedUpdate()
        {
            _movement.x = Input.GetAxisRaw("Horizontal"); 
            _movement.y = Input.GetAxisRaw("Vertical");

            _movement.Normalize();

            _rb2d.velocity = _movement * (speed * Time.deltaTime);
        }
        
        /*private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("OnCollisionEnter2D: " + collision.gameObject.tag);
           
            if (collision.gameObject.CompareTag("Door"))
            {
                Debug.Log("kolizja w playerze: " + collision.gameObject.tag);
                
                if (Input.GetAxis("Submit") > 0)
                {
                    Debug.Log("I pressed E > start interaction");
                    collision.gameObject.SendMessage("OpenDoor", 10);
                } 
               
            }
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            Debug.Log("OnTriggerStay2D in Player with: " + col.gameObject.tag); 
        }*/
    }
}
