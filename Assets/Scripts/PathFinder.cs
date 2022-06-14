using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawn _enemySpawn;
    WaveConfig _waveConfig;
    List<Transform> _waypoints;
    int WaypointIndex = 0;

    void Awake()
    {
        _enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    void Start()
    {
        _waveConfig = _enemySpawn.GetWaveConfig();
        _waypoints = _waveConfig.GetWaypoint();
        transform.position = _waypoints[WaypointIndex].position;
    }
    
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (WaypointIndex < _waypoints.Count)
        {
            Vector3 TargetPosition = _waypoints[WaypointIndex].position;
            float delta = _waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, delta);
            
            if (transform.position == TargetPosition)
            {
                WaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
