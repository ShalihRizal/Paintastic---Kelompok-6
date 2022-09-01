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

    /*[SerializeField]
    private TextMeshProUGUI player1ScoreText;
    [SerializeField]
    private TextMeshProUGUI player2ScoreText;*/
    [SerializeField]
    private TextMeshProUGUI[] playerScoreText;
    [SerializeField]
    private TextMeshProUGUI playerWonText;

    void OnEnable()
    {
        MatchHistory history = new MatchHistory();
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

            int[] index = scoreManager.GetPlayerScore();
            string[] dataPlayer = new string[index.Length];

            for(int i=0; i<index.Length; i++)
            {
                dataPlayer[i] = "Player" + (i + 1);
                Debug.Log(dataPlayer[i]);
            }
            history.PlayerRecord(dataPlayer, "Player"+ (highScoreIndex + 1));
        }
        else
        {
            playerWonText.text = "Draw !";
        }

    }
}
