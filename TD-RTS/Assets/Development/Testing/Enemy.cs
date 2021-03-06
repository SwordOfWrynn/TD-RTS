﻿using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    //so slowing knows what to set speed back to
    public float startSpeed = 10f;
    public float startHealth = 100;
    [HideInInspector]
    public float health;
    public int value = 25;
    public GameObject deathEffect;
    [Header("Unity Stuff")]
    public Image healthBar;

    [HideInInspector]
    public float speed;

    //Unity destroy takes time and could cause problems
    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float _amount)
    {
        health -= _amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
            Die();
    }

    public void Slow(float _percent)
    {
        speed = startSpeed * (1 - _percent);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += value;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, .5f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }
}
