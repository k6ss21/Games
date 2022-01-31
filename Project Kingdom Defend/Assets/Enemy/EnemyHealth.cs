using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float myHealth = 100f;
    [Tooltip("Add Health")]
    [SerializeField] float DifficultyClamp = 25f;
     float CurrHealth;
    Enemy enemy;
    private void OnEnable()
    {
        CurrHealth = myHealth;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnParticleCollision(GameObject other)
    {
        
        takeDamage(20f);
    }
    void takeDamage(float Damage)
    {
        CurrHealth -= Damage;
        if(CurrHealth <= 0)
        {
            enemy.RewardGold();
            gameObject.SetActive(false);
            myHealth += DifficultyClamp;
           
        }
    }
   
}
