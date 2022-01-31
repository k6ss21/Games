using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Score score;
    private void OnParticleCollision(GameObject other)
    {
        score.AddScore();
        Destroy(gameObject);
    }
}
