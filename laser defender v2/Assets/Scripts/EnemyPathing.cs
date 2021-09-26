using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveScript waveConfig;
    List<Transform> waypoints;
    float moveSpeed;


    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = waveConfig.GetMoveSpeed();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    public void SetWaveConfig(WaveScript waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    private void MoveEnemy()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
               
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
