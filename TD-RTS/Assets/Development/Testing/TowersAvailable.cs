using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersAvailable : MonoBehaviour {

    #region Singleton management
    public static TowersAvailable instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one TowerAvailable script in scene!");
            return;
        }
        instance = this;
    }
    #endregion

    public bool standardTower;
    public bool missileTower;
    public bool laserTower;

    private GameObject[] buildingButtons;
    private List<IsAvailable> isAvailableList;

    // Use this for initialization
    void Start () {
        buildingButtons = GameObject.FindGameObjectsWithTag("BuildingButtons");
        isAvailableList = new List<IsAvailable>();
        IsAvailable isAvailable;
        for (int i = 0; i < buildingButtons.Length; i++)
        {
            isAvailable = buildingButtons[i].GetComponent<IsAvailable>();
            isAvailableList.Add(isAvailable);
        }
    }

    public void CallCheckAvailable ()
    {
        for (int i = 0; i < isAvailableList.Count; i++)
        {
            isAvailableList[i].CheckAvailable();
        }
    }
}
