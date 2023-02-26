using com.maapiid.projectara.GameData;
using com.maapiid.projectara.Utils;
using com.maapiid.savesystem;
using UnityEngine;

namespace com.maapiid.projectara.Core
{
    public class Player : UnitySingleton<Player>, ISavable
    {
        [Header("Player settings")] 
        public float speed;
        public int xp;

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
        
        public object CaptureState() => new PlayerData().Capture(this);
        public void RestoreState(object state) => ((PlayerData)state).Restore(this);
    }
}
