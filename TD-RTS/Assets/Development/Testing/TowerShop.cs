using UnityEngine;

public class TowerShop : MonoBehaviour {

    //make one for each tower
    public TowerBlueprint standardTower;
    public TowerBlueprint missileTower;
    public TowerBlueprint laserTower;

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

    public void SelectLaserTower()
    {
        Debug.Log("Missile Tower selected");
        buildManager.SelectTowerToBuild(laserTower);
    }

}
