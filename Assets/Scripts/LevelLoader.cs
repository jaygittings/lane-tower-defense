using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int delay = 3;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadScene(currentSceneIndex + 1, delay));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadScene(int index, int delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene(index);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    internal void LoadNextScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex + 1);
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("Game Over Screen");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoanMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptions()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Options Screen");
    }

}
