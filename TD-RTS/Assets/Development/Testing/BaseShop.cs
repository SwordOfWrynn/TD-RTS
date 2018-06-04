using UnityEngine;

public class BaseShop : MonoBehaviour {

    //make one for each base building
    public BaseBlueprint test;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTest()
    {
        Debug.Log("Test selected");
        buildManager.SelectBaseToBuild(test);
    }

}
