using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/*Tells a cut-scene to begin playing, and then load a scene when completed.*/

namespace UI
{
    public class VideoController : MonoBehaviour
    {
        [SerializeField] VideoPlayer videoPlayer;
        [SerializeField] string whichScene;
        [SerializeField] GameObject activateObjectAfterPlaying;
        public long playerCurrentFrame;
        public long playerFrameCount;
    
        void Start()
        {
            InvokeRepeating("CheckOver", .1f, .1f);
        }
    
        private void CheckOver()
        {
            playerCurrentFrame = videoPlayer.frame;
            playerFrameCount = (int) videoPlayer.frameCount;

            if (playerCurrentFrame != 0 && playerFrameCount != 0)
            {
                if (playerCurrentFrame >= playerFrameCount - 1)
                {
                    if (activateObjectAfterPlaying != null)
                    {
                        activateObjectAfterPlaying.SetActive(true);
                        gameObject.SetActive(false);
                    }
                    else if (whichScene != "")
                    {
                        SceneManager.LoadScene(whichScene);
                    }

                    //Cancel Invoke since video is no longer playing
                    CancelInvoke("checkOver");
                }
            }
        }
    }
}
