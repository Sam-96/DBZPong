using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoreboard_Controller : MonoBehaviour {

    public static Scoreboard_Controller instance;

    public Text playerOneScoreTxt;
    public Text playerTwoScoreTxt;

    public int playerOneScore;
    public int playerTwoScore;
    

	// Use this for initialization
	void Start () {

        instance = this;

        playerOneScore = playerTwoScore = 0;
	}
	
	// Update is called once per frame
	void Update () {

    }


    public void GivePlayerOneAPoint()
    {

        playerOneScore += 1;

        playerOneScoreTxt.text = playerOneScore.ToString();

        //Vegeta's victory
        if(playerOneScore > 10)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void GivePlayerTwoAPoint()
    {

        playerTwoScore += 1;

        playerTwoScoreTxt.text = playerTwoScore.ToString();

        //Goku's victory
        if (playerTwoScore > 10)
        {
            SceneManager.LoadScene(3);
        }
    }
}
