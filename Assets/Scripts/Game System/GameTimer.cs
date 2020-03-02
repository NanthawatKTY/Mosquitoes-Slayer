using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in Seconds")]
    [SerializeField] float levelTimeInSeconds = 10;
    bool triggeredLevelFinished = false;

    private void Update()
    {
        if (triggeredLevelFinished) { return; } 
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimeInSeconds;

        var SliderValue = GetComponent<Slider>().maxValue;
        if (GetComponent<Slider>().value >= SliderValue)

        {

            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;  // ถ้าค่า slider > Slider value so triggeredLevelFinished = true
        }
    }
}
