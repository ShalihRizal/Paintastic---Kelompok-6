using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignButton : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    private string sceneName = "";

    private void Start()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClickEvent);
    }

    private void OnClickEvent()
    {
        LevelManager.instance.LoadLevel(sceneName);
    }
}
