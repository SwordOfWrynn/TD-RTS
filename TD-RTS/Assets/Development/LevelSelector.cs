using UnityEngine;

public class LevelSelector : MonoBehaviour {

    public SceneFader sceneFader;

    public void Select(string _levelName)
    {
        sceneFader.FadeTo(_levelName);
    }
    
}
