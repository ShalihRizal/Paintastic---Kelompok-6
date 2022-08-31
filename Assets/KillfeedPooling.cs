using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KillfeedPooling : MonoBehaviour
{

    [SerializeField]
    Killfeed killfeedPrefab;

    [SerializeField]
    Transform killfeedPanel;

    [SerializeField]
    UIManager uiManager;

    List<Killfeed> killfeedPool = new List<Killfeed>();

    [SerializeField]
    int initialSize = 10;

    void Start()
    {
        for (int i = 0; i < initialSize; i++)
        {
            InstantiateNewOne();
        }
    }
    private void OnEnable()
    {
        uiManager.OnScored += CreateKillFeed;
    }

    private void OnDisable()
    {
        uiManager.OnScored -= CreateKillFeed;
    }

    void InstantiateNewOne()
    {
        Killfeed killfeedRow = Instantiate(killfeedPrefab, killfeedPanel.transform);
        killfeedRow.gameObject.SetActive(false);
        killfeedPool.Add(killfeedRow);
    }

    public void CreateKillFeed(string playerName, int score)
    {
        foreach (Killfeed killfeed in killfeedPool)
        {
            if (!killfeed.gameObject.activeInHierarchy)
            {
                killfeed.GetComponentInChildren<TextMeshProUGUI>().text = "<b>" + playerName + "</b>" + " Scored " + score;
                killfeed.StartInit();
                return;
            }
        }
        InstantiateNewOne();
        CreateKillFeed(playerName, score);
    }
}
