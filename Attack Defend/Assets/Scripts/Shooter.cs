using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    float Maxdestroytime = 10f;
    float destroyTime;
    public TimBar timebar;

    float timerTime;

   // float score;

    private void Start()
    {
        //StartCoroutine(time());
        destroyTime = Maxdestroytime;
     timebar.SetMaxTime(Maxdestroytime);
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        timer();
         TimeRemaining();
       
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
    else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }
   private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
           return false;
        }
        else
        {
          return   true;
        }
    }

    public void Fire()
    {
		GameObject newProjectile = Instantiate(projectile,transform.position, projectile.transform.rotation);
        
       

    }

   

    public void TimeRemaining()
    {
        float remTime= destroyTime - timerTime;
        
        timebar.SetTime(remTime);
       
        if(remTime <=0)
        {
            Destroy(gameObject);
        }
        
    }

    public void timer()
    {
        timerTime += Time.deltaTime;
    }

 /*   IEnumerator time()
    {
        while (true)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }
    void timeCount()
    {
        score += 1;
    }*/
}
