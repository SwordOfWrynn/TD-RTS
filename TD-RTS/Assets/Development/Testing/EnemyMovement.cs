using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
    }

    private void Update()
    {
        Vector2 dir = target.position - transform.position;
        //multiply by Time.deltaTime so that the speed won't change based on frame rate
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            ReachEnd();
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void ReachEnd()
    {
        WaveSpawner.enemiesAlive--;
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

}
