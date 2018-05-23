using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color cantBuildColor;
    [Header("Optional")]
    public GameObject tower;

    [HideInInspector]
    public TowerBlueprint towerBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, -1);
    }

    void OnMouseDown()
    {

        //if mouse is on UI above node, node won't build
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //if there is already a tower
        if (tower != null)
        {
            //select node tower is on
            buildManager.SelectNode(this);
            return;
        }

        //if no tower is selected
        if (!buildManager.CanBuild)
            return;

        //Build a tower
        BuildTower(buildManager.GetTowerToBuild());
        //unselect tower type after building
        //buildManager.towerToBuild = null;
        
    }

    void BuildTower(TowerBlueprint _blueprint)
    {
        if (PlayerStats.Money < _blueprint.cost)
        {
            Debug.Log(PlayerStats.Money + " is not enough to build " + _blueprint.prefab.name);
            return;
        }

        PlayerStats.Money -= _blueprint.cost;
        
        GameObject newTower = Instantiate(_blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        tower = newTower;

        towerBlueprint = _blueprint;

        Debug.Log(_blueprint.prefab.name + " built. Money left = " + PlayerStats.Money);
    }

    public void UpgradeTower()
    {
        if(PlayerStats.Money < towerBlueprint.upgradeCost)
        {
            Debug.Log(PlayerStats.Money + " is not enough to upgrade " + towerBlueprint.prefab.name);
            return;
        }

        PlayerStats.Money -= towerBlueprint.upgradeCost;
        //Destroy old version of turret for new one
        Destroy(tower);
        //Build upgraded turret
        GameObject newTower = Instantiate(towerBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        tower = newTower;

        isUpgraded = true;
        Debug.Log(towerBlueprint.prefab.name + " upgraded. Money left = " + PlayerStats.Money);
    }

    public void SellTower()
    {
        PlayerStats.Money += towerBlueprint.GetSellAmount();
        Destroy(tower);
        tower = null;
        towerBlueprint = null;
        isUpgraded = false;
    }

    void OnMouseEnter()
    {
        //if mouse is on UI above node, node won't highlight
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = cantBuildColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
