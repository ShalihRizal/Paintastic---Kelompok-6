using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Paintastic.LevelManager
{
    public class LevelManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject loadingScreen;
        [SerializeField]
        private Slider loadingBar;
        [SerializeField]
        private TextMeshProUGUI progressText;

        public event System.Action<string> OnChangeScene;
        public static LevelManager instance;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                instance = this;
            }
        }

        public void LoadLevel(string sceneName)
        {
            OnChangeScene?.Invoke(sceneName);
            if (!(instance != null && instance != this))
            {
                StartCoroutine(LoadAsynchronously(sceneName));
            }
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
}