using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSwitching : MonoBehaviour {

    public GameObject towerShop;
    public GameObject baseShop;

	public void TurnOnTowerShop()
    {
        towerShop.SetActive(true);
        baseShop.SetActive(false);
    }

    public void TurnOnBaseShop()
    {
        baseShop.SetActive(true);
        towerShop.SetActive(false);
    }

}
