using UnityEngine;

/*Simple script telling Unity to Destroy this if it finds an identical one in the scene!*/

namespace com.maapiid.projectara.Core
{
    public class StartUp : MonoBehaviour
    {
        public bool dontDestroyOnLoad = false;
    
        // Start is called before the first frame update
        // Use this for initialization
        private void Awake()
        {
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            if (GameObject.Find("Startup") != null && GameObject.Find("Startup").CompareTag("Startup"))
            {
                Destroy(gameObject);
            }
        }
    }
}
