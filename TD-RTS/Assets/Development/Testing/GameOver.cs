using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public TextMeshProUGUI wavesText;
    public SceneFader sceneFader;
    
    void OnEnable()
    {
        wavesText.text = PlayerStats.Waves.ToString() + " Waves Survived";
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        sceneFader.FadeTo("MainMenu");
    }

}
