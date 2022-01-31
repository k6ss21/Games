using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100;
    float attackerHealth;
    [SerializeField] GameObject exploionVfx;
    int KillReward = 25;
    Animator animator;

    public HealthBar healthBar;
    [SerializeField] GameObject healthbar;


    private void Start()
    {
        attackerHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        animator = GetComponent<Animator>();
    }
    public void DealDamage(float damage)
    {
        attackerHealth -= damage;
        healthBar.SetHealth(attackerHealth);
        if (attackerHealth <= 0)
        {
            healthbar.SetActive(false);
            animator.SetBool("IsZombieDead", true);
            AddScoreAfterKill();
            DeathVFX();
        }
    }
    public void HitAttacker(float hitDamage)
    {
        attackerHealth -= hitDamage;
        if (attackerHealth <= 0)
        {
            
            Destroy(gameObject);
            AddScoreAfterKill();
            DeathVFX();
        }
    }

    


    private void AddScoreAfterKill()
    {
        var coinDisplay = FindObjectOfType<CoinScript>();
        coinDisplay.AddCoins(KillReward);
    }
    public float AttckerHealth()
    {
        return attackerHealth;
    }

    private void DeathVFX()
    {
        if (!exploionVfx)
        {
            return;
        }
        GameObject deathVFX = Instantiate(exploionVfx, transform.position, transform.rotation);

    }

    private void KillBullet()
    {
        Destroy(gameObject);
    }

    public void KnightDealDam(float damage)
    {
        Debug.Log("damagedealing" + damage);
        attackerHealth -= damage;
        healthBar.SetHealth(attackerHealth);
        if (attackerHealth <= 0f)
        {
            
            animator.SetBool("IsZombieDead", true);
        }
        //Debug.Log("attackhealt" + attackerHealth);
    }
  

}
