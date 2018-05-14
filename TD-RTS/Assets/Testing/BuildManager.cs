using UnityEngine;

public class BuildManager : MonoBehaviour {

    #region Singleton management
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
    #endregion
    public GameObject standardTowerPrefab;
    public GameObject missileTowerPrefab;

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject _tower)
    {
        towerToBuild = _tower;
    }

}
