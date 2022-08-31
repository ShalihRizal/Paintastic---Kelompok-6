using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ColorSelection;


public class ReadyState : MonoBehaviour
{
    [SerializeField]
    private bool[] isPlayerReady;

    [SerializeField]
    private GameObject NextButton;

    [SerializeField]
    ColorSelector colorSelector;

    public void ReadyPlayer(int index)
    {
        isPlayerReady[index] = !isPlayerReady[index];
        CheckCanStart();
    }
    private bool IsAllPlayerReady()
    {
        foreach(bool player in isPlayerReady)
        {
            if(!player)
            {
                return false;
            }
        }
        return true;
    }
    private void CheckCanStart()
    {
        if (IsAllPlayerReady())
        {
            NextButton.SetActive(true);
            /*for(int i=0; i<isPlayerReady.Length; i++)
            {
                PlayerPrefs.SetString("Player"+i+"Color", colorSelector.GetPlayerColor(i));
            }*/
            
        }
    }
}
