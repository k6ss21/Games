using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LivesText : MonoBehaviour
{
    float baselife = 6;
    float life;
    Text livesText;


    private void Start()
    {
        life = baselife - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateLives();
    }

    public void UpdateLives()
    {
        livesText.text = life.ToString();
    }

    public void TakeLife()
    {
        life = life - 1;
        if (life <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCodition();
        }
    }
}

  


