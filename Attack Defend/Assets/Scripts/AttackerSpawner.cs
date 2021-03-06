using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefab;
    bool spawn = true;
    IEnumerator Start()
    {

        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
           

        }
        
    }
   
    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefab.Length);
        Spawn(attackerPrefab[attackerIndex]);
       
        

    }

   public void StopSpawning()
    {
        spawn = false;
    }
  private void Spawn(Attacker myAttacker)
    {
        Attacker NewAttcker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        NewAttcker.transform.parent = transform;
    }
}
