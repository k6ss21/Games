using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TartgetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    [SerializeField] ParticleSystem projectionParticle;
    [SerializeField] float range = 15f;
    private void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;

        
    }
    void Update()
    {
        FindColsestenemy();
        TargetEnemy();
    }

    void FindColsestenemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDist = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDist = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDist < maxDist)
            {
                closestTarget = enemy.transform;
                maxDist = targetDist;
            }
        }
        target = closestTarget;
    }

    void TargetEnemy()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance <= range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
        weapon.LookAt(target);
        Vector3 eularRotation = weapon.transform.rotation.eulerAngles;
        weapon.transform.rotation = Quaternion.Euler(0, eularRotation.y, 0);
    }
    void Attack(bool isActive)
    {
        var emmisionModule = projectionParticle.emission;
        emmisionModule.enabled = isActive;
    }
}
