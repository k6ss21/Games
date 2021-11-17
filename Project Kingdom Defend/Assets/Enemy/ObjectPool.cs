using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] [Range(0,50)]int PoolSize = 5;
    [SerializeField] [Range(0.1f,30f)]float SpawnInterval = 1f;
    [SerializeField] GameObject enemyPrefab;
    bool stopSpawn = true;
    GameObject[] pool;

    int poolIndex = 0;
    private void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        stopSpawn = true;
       StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
       
    }

    void PopulatePool()
    {
        pool = new GameObject[PoolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
        stopSpawn = false;
    }

    void EnableObjectInPool()
    {
        for (int j = 0; j < pool.Length; j++)
        {
            if (pool[j].activeInHierarchy == false)
            {
                pool[j].SetActive(true);
                return;
            }
            
        }
        
        
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(SpawnInterval);
        }
       
    }
   
   
    
}
