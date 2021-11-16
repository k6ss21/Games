using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    float delay = 2f;
    int currentSceneIndex;
    string currentSceneName;
   

    string prevscene;
    
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Menu");
    }
   

    public void LoadMainGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptions()
    {
       
        SceneManager.LoadScene("Option Menu");
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    } 


      

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneName = SceneManager.GetActiveScene().name;
        
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitAndLoad());
        }
        IEnumerator WaitAndLoad()
        {
            yield return new WaitForSeconds(delay);
            LoadMainMenu();
        }


    }

}
