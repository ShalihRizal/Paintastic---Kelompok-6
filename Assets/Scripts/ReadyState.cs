using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyState : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer1Ready = false;
    [SerializeField]
    private bool isPlayer2Ready = false;

    [SerializeField]
    private GameObject NextButton;

    public void LoadScene(string sceneName)
    {
        if (isPlayer1Ready && isPlayer2Ready)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("The other player isn't ready yet");
        }
    }

    public void ReadyPlayer1()
    {
        isPlayer1Ready = !isPlayer1Ready;
    }

    public void ReadyPlayer2()
    {
        isPlayer2Ready = !isPlayer2Ready;
    }

    private void Update()
    {
        if (isPlayer1Ready && isPlayer2Ready)
        {
            NextButton.SetActive(true);
        }
    }
}
