using UnityEngine;

public class StartMenu : MonoBehaviour {

    public string levelToLoad = "MainMenu";

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
