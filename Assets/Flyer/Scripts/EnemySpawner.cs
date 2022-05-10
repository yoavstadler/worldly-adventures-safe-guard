using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping;
    
    private WaveConfig currentWave;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnWaves()
    {
        do
        {
            foreach (WaveConfig wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0f,0f,180f), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
