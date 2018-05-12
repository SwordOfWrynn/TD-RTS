using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager script in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTowerPrefab;

    private GameObject towerToBuild;

    void Start()
    {
        towerToBuild = standardTowerPrefab;
    }

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

}
