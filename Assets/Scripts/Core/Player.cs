using UnityEngine;

namespace com.maapiid.projectara.Core
{
    public class Player : MonoBehaviour
    {
        [Header("Player settings")]
        public float speed;
        
        private Vector2 _movement;
        private Rigidbody2D _rb2d;
        
        private void Awake()
        {
            Debug.Log("Awake Player");
        }
        private void Start()
        {
            Debug.Log("Start Player");
            _rb2d = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            _movement.x = Input.GetAxisRaw("Horizontal"); 
            _movement.y = Input.GetAxisRaw("Vertical");

            _movement.Normalize();

            _rb2d.velocity = _movement * (speed * Time.deltaTime);
        }
        
        private static Player _instance;
        public static Player Singleton
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<Player>();
                }
                return _instance;
            }
        }
    }
}
