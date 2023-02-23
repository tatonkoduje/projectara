using System;
using com.maapiid.savesystem;
using GameData;
using UnityEngine;

namespace com.maapiid.projectara.Core
{
    public class Player : MonoBehaviour, ISavable
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

        
        
        public object CaptureState()
        {
            return new PlayerData(this);
            /*var saveData = new SaveData
            {
                speed = speed,
                xp = xp,
                position = new float[3]
            };

            var position = gameObject.transform.position;
            saveData.position[0] = position.x;
            saveData.position[1] = position.y;
            saveData.position[2] = position.z;

            return saveData;*/
        }

        public void RestoreState(object state)
        {
            ((PlayerData)state).Restore(this);
            /*var saveData = (SaveData) state;
            speed = saveData.speed;
            xp = saveData.xp;

            var position = saveData.position;
            gameObject.transform.position = new Vector3(position[0], position[1], position[2]);*/
        }

        /*[Serializable]
        private struct SaveData
        {
            public float speed;
            public int xp;
            public float[] position;
        }*/
    }
}
