using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public GameObject healthBarPrefab;
    public Transform healthBar;
    public Image healthBarImage;
    public Canvas uiCanvas;
    public float offset;

    private float startHealth;
    private float health;

	// Use this for initialization
	void Start () {
        GameObject hp = Instantiate(healthBarPrefab);
        healthBar = hp.transform;
        uiCanvas = GameObject.Find("HPCanvas").GetComponent<Canvas>();
        healthBar.transform.SetParent(uiCanvas.transform, false);
        health = GetComponent<Enemy>().health;
        startHealth = GetComponent<Enemy>().startHealth;
        healthBarImage = healthBar.Find("HealthBar").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.position = Camera.main.WorldToScreenPoint((Vector3.up * offset) + transform.position);
        healthBarImage.fillAmount = health / startHealth;
    }
}
