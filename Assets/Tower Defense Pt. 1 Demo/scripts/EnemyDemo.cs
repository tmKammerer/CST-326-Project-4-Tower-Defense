using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death
    public float health = 5f;
    public float speed = 3f;
    public int coin = 5;
    
    public int targetWaypointIndex;

    private Transform target;

    public delegate void EnemyDied(EnemyDemo deadEnemy);

    public event EnemyDied OnEnemyDied;

    Vector3 targetPosition;

    bool enemyDied = false;

    public delegate void EnemyDestroyed(EnemyDemo enemy);
    public event EnemyDestroyed OnEnemyDestroyed;
    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        //   Place our enemy at the starting waypoint

        target = Waypoints.points[0];
        targetWaypointIndex = 1;
        targetPosition = Waypoints.points[targetWaypointIndex].position;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
       
        Vector3 movementDir = (targetPosition - transform.position).normalized;

        Vector3 newPosition = transform.position;
        newPosition += movementDir * speed * Time.deltaTime;
        

        transform.position = newPosition;
        // todo #4 Check if destination reaches or passed and change target
        if(Vector3.Distance(transform.position, targetPosition)<=0.2f)
        {
            TargetNextWaypoint();
        }
        
        
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        health--;
        Debug.Log("Health: " + health);
        if (health == 0)
        {
            Debug.Log("Dead");
            enemyDied = true;
            Destroy(gameObject);
        }
        if (enemyDied)
        {
            OnEnemyDied?.Invoke(this);
        }
    }


    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
        if (targetWaypointIndex >= Waypoints.points.Length-1)
        {
            Debug.Log("Ha! Ha! You suck!");
            coinManagement.lives--;
            Destroy(gameObject);
            return;
        }
        targetWaypointIndex++;
        targetPosition = Waypoints.points[targetWaypointIndex].position;
    }
    
}
