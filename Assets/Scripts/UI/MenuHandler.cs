using com.maapiid.projectara.Core;
using com.maapiid.savesystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
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
            MessageHolder.STRING_MESSAGE = "load";
            SceneManager.LoadScene(whichScene);
        }
        
        public void SaveGame()
        {
            GameManager.Instance.SaveGame();
        }
    
        public void OpenOptions()
        {
            //open options
        }
    }
}
