using UnityEngine;

[System.Serializable]
public class TowerBlueprint{

    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

}

[System.Serializable]
public class BaseBlueprint
{

    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public GameObject upgradedPrefab2;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

}
