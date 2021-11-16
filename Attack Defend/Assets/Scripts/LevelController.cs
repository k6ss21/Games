using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    [SerializeField] GameObject pauseScreen;
    int noofattacker = 0;
    bool levelTimeFinised = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        HandlePauseScreen();

    }

    private void HandlePauseScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {

                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {

                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
        }
    }

    public void AttackerSpawned()
    {
        noofattacker++;
    }

    public void AttckerKilled()
    {
        noofattacker--;
        if (noofattacker <= 0 && levelTimeFinised == true)
        {
            
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1.5f);
        
        FindObjectOfType<LevelLoader>().LoadMainMenu();

    }

    public void HandleLoseCodition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
    public void LevelTimerFinised()
    {
        levelTimeFinised = true;
        StopSpawners();

    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    
}
