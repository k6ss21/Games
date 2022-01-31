using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)]float speed = 1f;
    Enemy enemy;
    void OnEnable()
    {
        pathFind();
        ReturnToStart();
        StartCoroutine(FollowPath());
        transform.LookAt(path[1].transform.position);
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void pathFind()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            WayPoint wayPoint = child.GetComponent<WayPoint>();

            if (wayPoint != null)
            {
                path.Add(wayPoint);
            }
        
        }
    }
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    IEnumerator FollowPath()
    {
        
        foreach(WayPoint wayPoint in path)
        {

            Vector3 StartPos = transform.position;
            Vector3 endPos = wayPoint.transform.position;
            float travelPer = 0f;

            transform.LookAt(endPos);
            while (travelPer < 1)
            {
                travelPer += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(StartPos, endPos, travelPer);
                yield return new WaitForEndOfFrame();
            }
           
            
        }
        enemy.PenaltyGold();
        gameObject.SetActive(false);
    }

    

}
