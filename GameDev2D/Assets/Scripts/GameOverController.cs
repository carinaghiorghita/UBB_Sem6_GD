using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        string gameOverText;

        if (PlayerCollect.isTie)
            gameOverText = "It's a tie!\n" + PlayerCollect.tieScore + " points.";
        else
            gameOverText = "Congratulations " + PlayerCollect.winner + " points!";

        winnerText.text = gameOverText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
