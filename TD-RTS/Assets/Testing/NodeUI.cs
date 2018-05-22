using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellValue;
    public Button upgradeButton;

    private Node target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$ " + target.towerBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        sellValue.text = "$ " + target.towerBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTower();
        BuildManager.instance.DeselectNode();
    }

}
