using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score = 0;

    public void AddScore()
    {
        score += 1;
        Debug.Log("score : " + score);
    }
}
