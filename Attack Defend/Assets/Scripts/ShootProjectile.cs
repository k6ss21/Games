using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] float shootSpeed = 1f;
    
   
    void Update()
    {
        transform.Translate(Vector2.up * shootSpeed * Time.deltaTime);
    }
    /*private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        CollisonCount++;
        if(CollisonCount ==1)
        {
            var health = otherCollider.GetComponent<Health>();
            health.DealDamage(damage);
            Destroy(gameObject);

        }

    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }



}
