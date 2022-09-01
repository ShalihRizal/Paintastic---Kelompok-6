using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MatchRecordUI : MonoBehaviour
{
    [SerializeField]
    private Transform parent;

    private void Start()
    {
        MatchRecordManager matchRecordManager = new MatchRecordManager();

        AllMatchData matchData = matchRecordManager.LoadMatchRecord();

        for (int i = 0; i < matchData.MatchRecord.Length; i++)
        {
            int winnerIndex = -1;
            int index = 0;
            foreach (int item in matchData.MatchRecord[i].playersScore)
            {
                if (matchData.MatchRecord[i].playersScore.Max() == item)
                {
                    //Draw
                    if (winnerIndex != -1)
                    {
                        winnerIndex = -1;
                        break;
                    }
                    //Win
                    winnerIndex = index;
                }

                index++;
            }

            Color color = Color.white;


            if (winnerIndex >= 0)
            { 
                ColorUtility.TryParseHtmlString(matchData.MatchRecord[i].playersColor[winnerIndex], out color);
            }

            string playerString = "";
            string playerScore = "";

            for (int j = 0; j < matchData.MatchRecord[i].playersID.Length - 1; j++)
            {
                playerString += matchData.MatchRecord[i].playersID[j] + " Vs ";
                playerScore += matchData.MatchRecord[i].playersScore[j] + " - ";
            }

            playerString += matchData.MatchRecord[i].playersID[matchData.MatchRecord[i].playersID.Length - 1];
            playerScore += matchData.MatchRecord[i].playersScore[matchData.MatchRecord[i].playersScore.Length - 1];

            parent.GetChild(i).GetChild(0).GetComponent<Image>().color = color;
            parent.GetChild(i).GetChild(1).GetComponent<Image>().color = color;

            parent.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerString;
            parent.GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = playerScore;
            parent.GetChild(i).gameObject.SetActive(true);
        }

    }

}
