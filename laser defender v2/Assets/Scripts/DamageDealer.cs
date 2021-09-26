using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;
    [SerializeField] int damageToPlayer = 10;
    
   
    public int GetDamage()
    {
        return damage;
    }
    public int GetDamageToPlayer()
    {
        return damageToPlayer;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
