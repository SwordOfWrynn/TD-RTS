using UnityEngine;

public class Shop : MonoBehaviour {

    //make one for each tower
    public TowerBlueprint standardTower;
    public TowerBlueprint missileTower;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTower()
    {
        Debug.Log("Standard Tower selected");
        buildManager.SelectTowerToBuild(standardTower);
    }

    public void SelectMissileTower()
    {
        Debug.Log("Missile Tower selected");
        buildManager.SelectTowerToBuild(missileTower);
    }

}
