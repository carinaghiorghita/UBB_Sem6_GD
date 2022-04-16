using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollect : MonoBehaviour
{
    private int score = 0;
    public Text playerScoreText;
    public string player;

    private int spikeScore = -20;
    private int goldScore = 50;
    private int silverScore = 25;
    private int bronzeScore = 10;
    private int finishScore = 50;

    public static string winner;
    public static bool isTie=false;
    public static int tieScore;

    // Start is called before the first frame update
    void Start()
    {
        if (player == "Player 1")
            player = MenuController.player1;
        else
            player = MenuController.player2;

        playerScoreText.text = player + ": " + score;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int newScore = 0;

        if (collision.gameObject.CompareTag("Bronze") || collision.gameObject.CompareTag("Silver") || collision.gameObject.CompareTag("Gold"))
            Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag("Respawn"))
        {
            score += finishScore;
            playerScoreText.text = player + ": " + score;

            string[] player1ScoreString = GameObject.Find("Player1Score").GetComponent<Text>().text.Split(' ');
            string[] player2ScoreString = GameObject.Find("Player2Score").GetComponent<Text>().text.Split(' ');
            int player1Score = Int32.Parse(player1ScoreString[player1ScoreString.Length - 1]);
            int player2Score = Int32.Parse(player2ScoreString[player2ScoreString.Length - 1]);

            if (player1Score > player2Score)
                winner = GameObject.Find("Player1Score").GetComponent<Text>().text;
            else if (player1Score < player2Score)
                winner = GameObject.Find("Player2Score").GetComponent<Text>().text;
            else
            {
                isTie = true;
                tieScore = player1Score;
            }

            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.CompareTag("Spike"))
            newScore = spikeScore;
        else if (collision.gameObject.CompareTag("Gold"))
            newScore = goldScore;
        else if (collision.gameObject.CompareTag("Silver"))
            newScore = silverScore;
        else if (collision.gameObject.CompareTag("Bronze"))
            newScore = bronzeScore;

        score += newScore;
        playerScoreText.text = player + ": " + score;
    }
}
