using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveScript> WaveConfig;
    int startingWave = 0;
    [SerializeField] bool looping = false;

  

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWave());
        }
        while (looping);

    }
    private IEnumerator SpawnAllWave()
    {
        for(int waveIndex = startingWave; waveIndex <WaveConfig.Count; waveIndex++) 
        {
            var currentWave = WaveConfig[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));

        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveScript waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetnumberOfEnemies(); enemyCount++)
        {

            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetimeBetweenSpawn());
        }

    }
}
    
