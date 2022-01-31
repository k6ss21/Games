using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f , 5F)][SerializeField] float currentSpeed = 2f;

     int damage = 50;

    
    [SerializeField] int hitDamage = 50;

    GameObject curretTarget;

    Animator animator;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
     LevelController levelController =   FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttckerKilled();
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed *Time.deltaTime);
        UpdateAnimationEvent();
    }

    private void UpdateAnimationEvent()
    {
        if (!curretTarget)
        {
            animator.SetBool("IsZombieAttacking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = GetComponent<Health>();
        // Debug.Log(collision.name);
        if (collision.gameObject.tag == "DefenderProjectile")
        { 
             health.DealDamage(damage);
        }
        if (collision.gameObject.tag == "Defender")
        {
            animator.SetBool("IsZombieAttacking", true);
            curretTarget = collision.gameObject;
            
        }
       
        if (collision.gameObject.tag == "Shredder" )
        {
            animator.SetBool("IsZombieDead", true);

        }

        if (collision.gameObject.tag == "Knight")
        {
            SetMovementSpeed(0f);
            animator.SetBool("IsZombieAttacking", true);
        }
        
    }
    public void SetMovementSpeed(float Speed)
    {
        currentSpeed = Speed;
    }

    public void GiveDamage(float damage)
    {
        if (!curretTarget) { return; }
        var otherHealth = curretTarget.GetComponent<Defender>();
        otherHealth.TakeDamage();
        
    }
  
    
}

    


