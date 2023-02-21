using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.maapiid.projectara.UI
{
    public class MenuHandler : MonoBehaviour
    {
        [SerializeField] private string whichScene;

        public void QuitGame()
        {
            Application.Quit();
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(whichScene);
        }
    
        public void LoadGame()
        {
            //load game
        }
    
        public void OpenOptions()
        {
            //open options
        }
    }
}
