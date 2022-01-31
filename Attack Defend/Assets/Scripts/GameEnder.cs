using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnder : MonoBehaviour
{
    LivesText lifetext;

    private void Start()
    {
         lifetext = FindObjectOfType<LivesText>();
    }
    private void OnTriggerEnter2D()
    {
        lifetext.TakeLife();
        lifetext.UpdateLives();
    }


   
}
   