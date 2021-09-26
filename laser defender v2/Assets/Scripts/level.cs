using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level : MonoBehaviour
{

    [SerializeField] float delay = 1f;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadMainGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndload());
    }
        
    IEnumerator WaitAndload()
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene("Game over");
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
