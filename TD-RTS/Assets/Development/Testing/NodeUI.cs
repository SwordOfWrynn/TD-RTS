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

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            if (!target.isBaseNode)
                upgradeCost.text = "$ " + target.towerBlueprint.upgradeCost;
            else
                upgradeCost.text = "$" + target.baseBlueprint.upgradeCost;

            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        if (!target.isBaseNode)
            sellValue.text = "$ " + target.towerBlueprint.GetSellAmount();
        else
            sellValue.text = "$" + target.baseBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        if (!target.isBaseNode)
            target.UpgradeTower();
        else
            target.UpgradeBase();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        if (!target.isBaseNode)
            target.SellTower();
        else
            target.SellBase();
        BuildManager.instance.DeselectNode();
    }

}
