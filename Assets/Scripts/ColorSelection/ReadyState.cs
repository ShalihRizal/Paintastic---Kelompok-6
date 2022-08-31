using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ColorSelection;


public class ReadyState : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer1Ready = false;
    [SerializeField]
    private bool isPlayer2Ready = false;

    [SerializeField]
    private GameObject NextButton;

    [SerializeField]
    ColorSelector colorSelector;

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
            PlayerPrefs.SetString("Player1Color", colorSelector.GetPlayer1Color());
            PlayerPrefs.SetString("Player2Color", colorSelector.GetPlayer2Color());
        }
    }
}
