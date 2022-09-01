using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.ScoreManager;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class Result : MonoBehaviour
{

    [SerializeField]
    ScoreManager scoreManager;

    [SerializeField]
    private TextMeshProUGUI[] playerScoreText;

    [SerializeField]
    private TextMeshProUGUI playerWonText;

    void OnEnable()
    {
        MatchHistory history = new MatchHistory();
        MatchRecordManager matchRecordManager = new MatchRecordManager();  

        for(int i = 0; i < playerScoreText.Length; i++)
        {
            playerScoreText[i].text = "Player " + (i+1) + " score : " + scoreManager.GetPlayerScore(i).ToString();
        }
        
        int highScore = scoreManager.GetPlayerScore().Max();
        int highScoreIndex = scoreManager.GetPlayerScore().ToList().IndexOf(highScore);

        int sameScore = 0;
        foreach(int _playerScore in scoreManager.GetPlayerScore())
        {
            if(highScore == _playerScore)
            {
                sameScore += 1;
            }
        }

        Time.timeScale = 0;
        if (sameScore == 1)
        {
            playerWonText.text = "Player "+ (highScoreIndex + 1) +" Won";
            history.OnPlayerWin("Player"+ (highScoreIndex + 1));

            string[] playersColor = new string[scoreManager.GetPlayerScore().Length];
            string[] playersID = new string[scoreManager.GetPlayerScore().Length];

            for (int i = 0; i < playersColor.Length; i++)
            {
                playersID[i] = "Player" + (i + 1);
                playersColor[i] = PlayerPrefs.GetString(playersID[i] + "Color");
            }

            matchRecordManager.RecordMatch(playersID, scoreManager.GetPlayerScore(), playersColor);
        }
        else
        {
            playerWonText.text = "Draw !";
        }

    }
}
