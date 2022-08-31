using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public Button pauseButton;

    public Button ResumeButton;

    [SerializeField]
    bool isPaused = false;

    private void Start()
    {
        pauseButton.onClick.RemoveAllListeners();
        pauseButton.onClick.AddListener(PauseGame);

        ResumeButton.onClick.RemoveAllListeners();
        ResumeButton.onClick.AddListener(PauseGame);
    }

    void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = !isPaused;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = !isPaused;
            Time.timeScale = 1;
        }
    }
}
