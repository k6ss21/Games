using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    float HorizontalValue = 0f;

    float runSpeed = 40f;

    int Coin= 0;
    public GameObject levelOvercanvas;
    public CharacterController2D characterController;

    public Rigidbody2D myrigidbody;
    public  Animator animator;
    public Joystick joystick;

    bool jump = false;
    private void Start()
    {
        levelOvercanvas.SetActive(false);
        Coin = FindObjectsOfType<CoinScript>().Length;
        Debug.Log("length" + Coin);
    }
    void Update()
    {
        HorizontalValue = joystick.Horizontal * runSpeed ;
        animator.SetFloat("Speed", Mathf.Abs(HorizontalValue));
        
       

    }

    public void Jump()
    {
       
            jump = true;
            animator.SetBool("IsJumping", true);
        
        
    }
    public void FixedUpdate()
    {
       // Debug.Log(HorizontalValue);
        characterController.Move(HorizontalValue * Time.deltaTime, false, jump);
       // Debug.Log(myrigidbody.velocity);
        jump = false;
        
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void CoinCount()
    {
        Coin -= 1;
       // Debug.Log("CoinCount= " +Coin);

    }

    public int CoinReturn()
    {
        return Coin;
    }

    public void EndGame()
    {
        if (Coin <= 0 )
        {
            Time.timeScale = 0;
            levelOvercanvas.SetActive(true);
        }
        else
        {
            Debug.Log("Collect All Coins");
        }
    }
}
