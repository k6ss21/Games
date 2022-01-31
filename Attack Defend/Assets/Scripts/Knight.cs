using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    AttackerSpawner myLaneSpawner;
    Animator animator;
    [SerializeField] float distanceBetween;



    float Maxdestroytime = 10f;
    float destroyTime;
    public TimBar timebar;

    float timerTime;

    // Start is called before the first frame update
    void Start()
    {
        destroyTime = Maxdestroytime;
        timebar.SetMaxTime(Maxdestroytime);
        KnightAttack();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer();
        TimeRemaining();

        if (IsAttackerInLane())
        {
            NearDefender();
            
        }
        
    }

    public void KnightAttack()
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
        if (myLaneSpawner.transform.childCount <= 0)
        {
            
            return false;
        }
        else
        {
            return true;
        }
    }

    public void KnightDealDamage(float damage)
    {
        GameObject child = myLaneSpawner.transform.GetChild(0).gameObject;
        

        child.GetComponent<Health>().KnightDealDam(damage);
    }
    private void NearDefender()
    {
        GameObject child = myLaneSpawner.transform.GetChild(0).gameObject;
        float IsNearDefender = child.transform.position.x - transform.position.x;
       
        if (IsNearDefender >= 0 && IsNearDefender <= distanceBetween) 
        {
            animator.SetBool("closeAttack", true);
            
        }
        else
        {
            animator.SetBool("closeAttack", false);
        }
    }
  

    public void TimeRemaining()
    {
        float remTime = destroyTime - timerTime;

        timebar.SetTime(remTime);

        if (remTime <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void timer()
    {
        timerTime += Time.deltaTime;
    }

}
