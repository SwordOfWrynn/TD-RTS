using UnityEngine;

public class BaseShop : MonoBehaviour {

    //make one for each base building
    public BaseBlueprint test;
    public BaseBlueprint resourceProducer;

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

    public void SelectResourceProducer()
    {
        Debug.Log("Resource selected");
        buildManager.SelectBaseToBuild(resourceProducer);
    }

}
