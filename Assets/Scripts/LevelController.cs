using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel = null;
    [SerializeField] GameObject loseLabel = null;
    [SerializeField] AudioClip[] clips = null;

    int enemiesInLevel = 0;
    bool timerIsDone = false;
    bool levelWon = false;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInLevel = 0;
        timerIsDone = false;
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AttackerSpawned()
    {
        enemiesInLevel++;
    }

    public void AttackerKilled()
    {

        enemiesInLevel--;
        if (levelWon) return;

        if(enemiesInLevel <= 0 && timerIsDone)
        {
            levelWon = true;
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            StartCoroutine(NextLevel());
            //Debug.Log("Level won");
        }
    }

    internal void Lose()
    {
        loseLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(clips[1], Camera.main.transform.position);
        Time.timeScale = 0;
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<LevelLoader>().LoadNextScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetTimerIsDone()
    {
        timerIsDone = true;
        var spawners = FindObjectsOfType<EnemySpawner>();
        foreach(EnemySpawner e in spawners)
        {
            e.DisableSpawning();
        }
    }
}
