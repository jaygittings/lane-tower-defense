using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] [Tooltip("Level time in seconds.")] float levelTime = 10f;

    bool timerFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerFinished) return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        timerFinished = Time.timeSinceLevelLoad > levelTime;

        if(timerFinished)
        {
            FindObjectOfType<LevelController>().SetTimerIsDone();
        }
    }
}
