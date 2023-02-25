using com.maapiid.projectara.Core;
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
