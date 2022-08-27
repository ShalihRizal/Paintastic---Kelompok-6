using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    private GameObject loadingScreen;
    [SerializeField]
    private Slider loadingBar;
    [SerializeField]
    private TextMeshProUGUI progressText;

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingBar.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }


}
