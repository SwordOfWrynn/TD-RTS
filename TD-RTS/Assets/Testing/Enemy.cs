using UnityEngine;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int value = 25;
    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float _amount)
    {
        health -= _amount;
        if (health <= 0)
            Die();
    }

    public void Slow(float _percent)
    {
        speed = startSpeed * (1 - _percent);
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, .5f);
        
        Destroy(gameObject);
    }
}
