using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color cantBuildColor;
    [Header("Optional")]
    public GameObject tower;

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

        //if no tower is selected
        if (!buildManager.CanBuild)
            return;

        //if there is already a tower
        if (tower != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        //Build a tower
        buildManager.BuildTowerOn(this);
        
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
