using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryManager : MonoBehaviour
{
    [SerializeField]
    Transform parent;
    [SerializeField]
    Transform entityPlayers;
    private void Start()
    {
        MatchHistory matchHistory = new MatchHistory();
        ArrayPlayer players = new ArrayPlayer();
        players.arrayPlayer = matchHistory.LoadData();
        for (int i=0; i<players.arrayPlayer.Length; i++)
        {
            for (int j=0; j<=i; j++)
            {
                if (players.arrayPlayer[j].winCount < players.arrayPlayer[i].winCount)
                {
                    PlayerData temp = players.arrayPlayer[j];
                    players.arrayPlayer[j] = players.arrayPlayer[i];
                    players.arrayPlayer[i] = temp;
                }
            }
        }
        
        int index = 1;
        foreach (PlayerData player in players.arrayPlayer)
        {
            parent.GetComponent<RectTransform>().sizeDelta = new Vector2(
                parent.GetComponent<RectTransform>().sizeDelta.x,
                parent.GetComponent<RectTransform>().sizeDelta.y + entityPlayers.GetComponent<RectTransform>().sizeDelta.y
                );
            Transform t = Instantiate(entityPlayers, parent);
            t.GetChild(0).GetComponent<Text>().text = index.ToString();
            t.GetChild(1).GetComponent<Text>().text = player.id;
            t.GetChild(2).GetComponent<Text>().text = player.winCount.ToString();
            index++;
        }
    }
}