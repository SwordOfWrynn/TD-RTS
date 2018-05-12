using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;

    private GameObject tower;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        //if there is already a tower
        if (tower != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        //Build a tower

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        tower = Instantiate(towerToBuild, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
