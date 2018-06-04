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

    public TowerBlueprint towerToBuild;
    public BaseBlueprint baseToBuild;
    private Node selectedNode;

    //if towerToBuild not equal to null returns true, else returns false
    public bool CanBuildTower { get { return towerToBuild != null; } }
    public bool CanBuildBase { get { return baseToBuild != null; } }
    public bool HasMoneyTower { get { return PlayerStats.Money >= towerToBuild.cost; } }
    public bool HasMoneyBase { get { return PlayerStats.Money >= baseToBuild.cost; } }
    public NodeUI nodeUI;

    public void SelectNode(Node _node)
    {
        if(selectedNode == _node)
        {
            DeselectNode();
            return;
        }

        selectedNode = _node;
        towerToBuild = null;
        baseToBuild = null;

        nodeUI.SetTarget(_node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTowerToBuild(TowerBlueprint _tower)
    {
        towerToBuild = _tower;
        baseToBuild = null;
        DeselectNode();
    }

    public void SelectBaseToBuild(BaseBlueprint _base)
    {
        baseToBuild = _base;
        towerToBuild = null;
        DeselectNode();
    }

    //tell other scripts what tower is selected without making towerToBuild public
    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }

    //tell other scripts what base is selected without making baseToBuild public
    public BaseBlueprint GetBaseToBuild()
    {
        return baseToBuild;
    }

}
