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
        /*player1ScoreText.text = "Player 1 score : " + scoreManager.GetPlayer1Score().ToString();
        player2ScoreText.text = "Player 2 score : " + scoreManager.GetPlayer2Score().ToString();*/
        for(int i = 0; i < playerScoreText.Length; i++)
        {
            playerScoreText[i].text = "Player" + (i) + " score : " + scoreManager.GetPlayerScore(i).ToString();
        }

        if (scoreManager.GetPlayerScore(0) > scoreManager.GetPlayerScore(1))
        {
            Time.timeScale = 0;
            playerWonText.text = "Player 1 Won";
        }
        else if (scoreManager.GetPlayerScore(1) > scoreManager.GetPlayerScore(0))
        {
            Time.timeScale = 0;
            playerWonText.text = "Player 2 Won";
        }
        else
        {
            Time.timeScale = 0;
            playerWonText.text = "Draw !";
        }
        /*int highScore = scoreManager.GetPlayerScore().Max();
        int highScoreIndex = scoreManager.GetPlayerScore().ToList().IndexOf(highScore);*/

    }
}
