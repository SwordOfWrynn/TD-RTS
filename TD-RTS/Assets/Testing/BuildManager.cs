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
    private Node selectedNode;

    //if towerToBuild not equal to null returns true, else returns false
    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }
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
        DeselectNode();
    }

    //tell other scripts what tower is selected without making towerToBuild public
    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }

}
