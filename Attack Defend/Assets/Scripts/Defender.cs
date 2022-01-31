using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] int CoinCost= 100;
    [SerializeField] int Health =100;
    [SerializeField] int damage = 50;
    
    public int GetCoinCost()
    {
        return CoinCost;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void TakeDamage()
    {
        Health -= damage;
        if(Health <=0)
        {
            Destroy(gameObject);
            
        }
    }
    
  
}
