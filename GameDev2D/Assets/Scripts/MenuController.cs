using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public static string player1 = "Player 1";
    public static string player2 = "Player 2";

    void Start()
    {
        var input1 = GameObject.Find("Player1Input").GetComponent<InputField>();
        input1.onEndEdit.AddListener(Player1Name);

        var input2 = GameObject.Find("Player2Input").GetComponent<InputField>();
        input2.onEndEdit.AddListener(Player2Name);

    }

    private void Player1Name(string name)
    {
        player1 = name;
    }

    private void Player2Name(string name)
    {
        player2 = name;
    }

    public void StartGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
