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

    public void PurchaseStandardTower()
    {
        Debug.Log("Standard Tower selected");
        buildManager.SetTowerToBuild(buildManager.standardTowerPrefab);
    }

    public void PurchaseMissileTower()
    {
        Debug.Log("Missile Tower selected");
        buildManager.SetTowerToBuild(buildManager.missileTowerPrefab);
    }

}
