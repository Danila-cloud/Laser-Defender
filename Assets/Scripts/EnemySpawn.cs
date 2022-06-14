using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] WaveConfig _waveConfig;
    void Start()
    {
        Spawn();
    }

    public WaveConfig GetWaveConfig()
    {
        return _waveConfig;
    }
    void Spawn()
    {
        for (int i = 0; i < _waveConfig.GetEnemyCount(); i++)
        {
            Instantiate(_waveConfig.GetEnemyPrefab(i), _waveConfig.GetStartingWaypoint().position, Quaternion.identity, transform);

        }
    }
}
