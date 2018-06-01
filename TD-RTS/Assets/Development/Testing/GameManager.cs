using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverUI;
    public GameObject gameWonUI;
    public int levelToUnlock;

    public static bool GameIsOver;

    void Start()
    {
        GameIsOver = false;
    }


    // Update is called once per frame
    void Update () {
        if (GameIsOver)
            return;

		if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
    //called from WaveSpawner
    public void WinLevel()
    {
        GameIsOver = true;
        Debug.Log("Level Won");
        //save level passed
        gameWonUI.SetActive(true);
    }

}
