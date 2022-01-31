using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gametimer : MonoBehaviour
{
    [Tooltip("level timer in sec")]
     float levelTimer = 60f;
    bool TriggerdLevelFinised = false;

    // Update is called once per frame
    void Update()
    {
        if (TriggerdLevelFinised) { return; }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimer;

        bool timeFinished = (Time.timeSinceLevelLoad >= levelTimer);
        if (timeFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinised();
            TriggerdLevelFinised = true;
        }
        
    }
}
