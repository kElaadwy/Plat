using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

    [SerializeField] Transform[] waypoints;
    int currentWayPointIndex = 0;
    [SerializeField] float speed = 1f;

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWayPointIndex].position) <= 0.1)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= waypoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position,
            waypoints[currentWayPointIndex].position, speed * Time.deltaTime);
    }
}
