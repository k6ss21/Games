using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnit = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //cached object
    GameStatus theGamestatus;
    ball theBall;
    void Start()
    {
        theGamestatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<ball>();
    }

    void Update()
    {
        
        Vector2 PaddlePos = new Vector2 (transform.position.x,transform.position.y);
        PaddlePos.x = Mathf.Clamp (GetXPos(), minX, maxX);
        transform.position = PaddlePos;
    }
    private float GetXPos()
    {
        if(theGamestatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x /Screen.width * screenWidthUnit;
        }
    }
}
