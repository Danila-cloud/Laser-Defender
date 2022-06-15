using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> Waves;
    [SerializeField] private float TimeBetweenWaves = 1f;
    private WaveConfig _waveConfig;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfig GetWaveConfig()
    {
        return _waveConfig;
    }
    IEnumerator SpawnEnemyWaves()
    {
        bool isLooping = true;
        while(isLooping)
        {
            foreach (WaveConfig Wave in Waves)
            {
                _waveConfig = Wave;
                for (int i = 0; i < _waveConfig.GetEnemyCount(); i++)
                {
                    Instantiate(_waveConfig.GetEnemyPrefab(i), _waveConfig.GetStartingWaypoint().position,
                        Quaternion.identity,
                        transform);
                    yield return new WaitForSeconds(_waveConfig.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(TimeBetweenWaves);
            }
        }
    }
}
