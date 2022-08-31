using UnityEngine.UI;
using UnityEngine;

public class SceneButtonName : MonoBehaviour
{
    public Button button;
    public string sceneName;

    public void OnClickEventChangeScene()
    {
        LevelManager.instance.LoadLevel(sceneName);
    }
}