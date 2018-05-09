using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10.0f;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoints[0];
    }

    private void Update()
    {
        Vector2 dir = target.position - transform.position;
        //multiply by Time.deltaTime so that the speed won't change based on frame rate
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length -1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

}
