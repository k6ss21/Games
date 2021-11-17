using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField]GameObject explosion;
    public Rigidbody rigidbody;
    private void Start()
    {
        explosion.SetActive(false);
    }
    private void OnCollisionEnter(Collision other)
    {

        crashHandler();
    }

    void crashHandler()
    {
        GetComponent<PlayerControl>().enabled = false;
        explosion.SetActive(true);
        
        Invoke("RestartLevel", 1f);
    }
    void RestartLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentIndex);
    }
}
