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

    private TowerBlueprint towerToBuild;
    //if towerToBuild not equal to null returns true, else returns false
    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

    public void BuildTowerOn(Node _node)
    {
        if (PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("Need more money, " + PlayerStats.Money + " is not enough to build " + towerToBuild.prefab.name);
            return;
        }

        PlayerStats.Money -= towerToBuild.cost;

        GameObject tower = Instantiate(towerToBuild.prefab, _node.GetBuildPosition(), Quaternion.identity);
        _node.tower = tower;
        Debug.Log(towerToBuild.prefab.name + " built. Money left = " + PlayerStats.Money);
    }

    public void SelectTowerToBuild(TowerBlueprint _tower)
    {
        towerToBuild = _tower;
    }

}
