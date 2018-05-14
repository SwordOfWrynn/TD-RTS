using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;

    private GameObject tower;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {

        //if mouse is on UI above node, node won't build
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //if no tower is selected
        if (buildManager.GetTowerToBuild() == null)
            return;

        //if there is already a tower
        if (tower != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        //Build a tower

        GameObject towerToBuild = buildManager.GetTowerToBuild();
        tower = Instantiate(towerToBuild, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
    }

    void OnMouseEnter()
    {
        //if mouse is on UI above node, node won't highlight
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTowerToBuild() == null)
            return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
