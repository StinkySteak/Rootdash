using StinkySteak.Rootdash.Util;
using UnityEngine.SceneManagement;

namespace StinkySteak.Rootdash.Loader
{
    public class SceneLoader : MonoSingleton<SceneLoader>
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}