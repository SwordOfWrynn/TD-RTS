using UnityEngine;
using UnityEngine.UI;

public class IsAvailable : MonoBehaviour {

    [Tooltip("Use var format e.g. standardTower")]
    public string towerType;
    public Sprite lockedSprite;
    public Image image;

    private Sprite startSprite;
    private Color startColor;
    private TowersAvailable towersAvailable;

    // Use this for initialization
    void Start()
    {
        startSprite = image.sprite;
        startColor = image.color;
        towersAvailable = TowersAvailable.instance;
        CheckAvailable();
    }

    public void CheckAvailable () {
        Debug.Log("Checking Availability");
        if (towerType == "standardTower")
        {
            if (!towersAvailable.standardTower)
            {
                GetComponent<Button>().interactable = false;
                image.sprite = lockedSprite;
                image.color = Color.white;
            }
            else
            {
                GetComponent<Button>().interactable = true;
                image.sprite = startSprite;
                image.color = startColor;
            }
        }
        if (towerType == "missileTower")
        {
            if (!towersAvailable.missileTower)
            {
                GetComponent<Button>().interactable = false;
                image.sprite = lockedSprite;
                image.color = Color.white;
            }
            else
            {
                GetComponent<Button>().interactable = true;
                image.sprite = startSprite;
                image.color = startColor;
            }
        }
        if (towerType == "laserTower")
        {
            if (!towersAvailable.laserTower)
            {
                GetComponent<Button>().interactable = false;
                image.sprite = lockedSprite;
                image.color = Color.white;
            }
            else
            {
                GetComponent<Button>().interactable = true;
                image.sprite = startSprite;
                image.color = startColor;
            }
        }
    }
}
