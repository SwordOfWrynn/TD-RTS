using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public bool isBaseNode = false;
    public Color hoverColor;
    public Color cantBuildColor;
    [Header("Optional")]
    public GameObject building;

    [HideInInspector]
    public TowerBlueprint towerBlueprint;
    [HideInInspector]
    public BaseBlueprint baseBlueprint;
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
        if (building != null)
        {
            //select node tower is on
            buildManager.SelectNode(this);
            return;
        }

        //if no tower or base is selected
        if (!buildManager.CanBuildTower && !buildManager.CanBuildBase)
            return;

        if (!isBaseNode)
        {
            //Build a tower
            BuildTower(buildManager.GetTowerToBuild());
            //unselect tower type after building
            //buildManager.towerToBuild = null;
        }
        else
        {
            //Build base building
            BuildBase(buildManager.GetBaseToBuild());
            //unselect building type after building
            buildManager.baseToBuild = null;
        }

    }

    void BuildTower(TowerBlueprint _blueprint)
    {
        if (PlayerStats.Money < _blueprint.cost)
        {
            return;
        }

        PlayerStats.Money -= _blueprint.cost;
        
        GameObject newBuilding = Instantiate(_blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        building = newBuilding;

        towerBlueprint = _blueprint;
        
    }

    public void UpgradeTower()
    {
        if(PlayerStats.Money < towerBlueprint.upgradeCost)
        {
            return;
        }

        PlayerStats.Money -= towerBlueprint.upgradeCost;
        //Destroy old version of turret for new one
        Destroy(building);
        //Build upgraded turret
        GameObject newBuilding = Instantiate(towerBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        building = newBuilding;

        isUpgraded = true;
    }

    public void SellTower()
    {
        PlayerStats.Money += towerBlueprint.GetSellAmount();
        Destroy(building);
        building = null;
        towerBlueprint = null;
        isUpgraded = false;
    }

    void BuildBase(BaseBlueprint _blueprint)
    {
        if (PlayerStats.Money < _blueprint.cost)
        {
            return;
        }

        PlayerStats.Money -= _blueprint.cost;

        GameObject newBuilding = Instantiate(_blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        building = newBuilding;

        baseBlueprint = _blueprint;
    }

    public void UpgradeBase()
    {
        if (PlayerStats.Money < baseBlueprint.upgradeCost)
        {
            return;
        }

        PlayerStats.Money -= baseBlueprint.upgradeCost;
        //Destroy old version of building for new one
        Destroy(building);
        //Build upgraded building
        GameObject newBuilding = Instantiate(baseBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        building = newBuilding;

        isUpgraded = true;
        Debug.Log(baseBlueprint.prefab.name + " upgraded. Money left = " + PlayerStats.Money);
    }

    public void SellBase()
    {
        PlayerStats.Money += baseBlueprint.GetSellAmount();
        Destroy(building);
        building = null;
        baseBlueprint = null;
        isUpgraded = false;
    }

    void OnMouseEnter()
    {
        //if mouse is on UI above node, node won't highlight
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuildTower && !buildManager.CanBuildBase)
            return;

        if (!isBaseNode)
        {
            if (buildManager.HasMoneyTower)
            {
                rend.material.color = hoverColor;
            }
            else
            {
                rend.material.color = cantBuildColor;
            }
        }
        
        if (isBaseNode)
        {
            if (buildManager.HasMoneyBase)
            {
                rend.material.color = hoverColor;
            }
            else
            {
                rend.material.color = cantBuildColor;
            }
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
