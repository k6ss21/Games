using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveScript : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] float spawnRandomfactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWavepoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWavepoints.Add(child);
        }
        return waveWavepoints;
    }
    public float GetimeBetweenSpawn()
    {
        return timeBetweenSpawn;

    }
    public float GetspawnRandomfactor()
    {
        return spawnRandomfactor;
    }
    public int GetnumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }


}
