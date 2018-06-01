using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public SceneFader sceneFader;

    public Button[] levelButtons;

    void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
    }

    public void Select(string _levelName)
    {
        sceneFader.FadeTo(_levelName);
    }
    
}
