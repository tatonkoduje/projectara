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
        
        }

        private void FixedUpdate()
        {
            _movement.x = Input.GetAxisRaw("Horizontal"); 
            _movement.y = Input.GetAxisRaw("Vertical");

            _movement.Normalize();

            _rb2d.velocity = _movement * (speed * Time.deltaTime);
        }
    }
}
