using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave config", fileName = "New wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> EnemyPrefab;
    [SerializeField] Transform PathPrefab;

    [SerializeField] float moveSpeed = 5f;

    public Transform GetStartingWaypoint()
    {
        return PathPrefab.GetChild(0);
    }

    public int GetEnemyCount()
    {
        return EnemyPrefab.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return EnemyPrefab[index];
    }

    public List<Transform> GetWaypoint()
    {
        List<Transform> Waypoints = new List<Transform>();
        foreach (Transform child in PathPrefab)
        {
            Waypoints.Add(child);
        }

        return Waypoints;
    }
    

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
