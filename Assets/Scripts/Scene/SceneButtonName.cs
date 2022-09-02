using UnityEngine.UI;
using UnityEngine;

namespace Paintastic.AsignButton
{
    public class SceneButtonName : MonoBehaviour
    {
        public Button button;
        public string sceneName;

        public void OnClickEventChangeScene()
        {
            LevelManager.LevelManager.instance.LoadLevel(sceneName);
        }
    }
}