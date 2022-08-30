using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.ScoreManager;
using UnityEngine.UI;
using TMPro;


public class Result : MonoBehaviour
{

    [SerializeField]
    ScoreManager scoreManager;

    [SerializeField]
    private TextMeshProUGUI player1ScoreText;
    [SerializeField]
    private TextMeshProUGUI player2ScoreText;
    [SerializeField]
    private TextMeshProUGUI playerWonText;

    void OnEnable()
    {
        MatchHistory history = new MatchHistory();
        player1ScoreText.text = "Player 1 score : " + scoreManager.GetPlayer1Score().ToString();
        player2ScoreText.text = "Player 2 score : " + scoreManager.GetPlayer2Score().ToString();
        if (scoreManager.GetPlayer1Score() > scoreManager.GetPlayer2Score())
        {
            Time.timeScale = 0;
            playerWonText.text = "Player 1 Won";
            history.OnPlayerWin("Player1");
        }
        else if (scoreManager.GetPlayer2Score() > scoreManager.GetPlayer1Score())
        {
            Time.timeScale = 0;
            playerWonText.text = "Player 2 Won";
            history.OnPlayerWin("Player2");
        }
        else
        {
            Time.timeScale = 0;
            playerWonText.text = "Draw !";
        }
    }
}
