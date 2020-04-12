using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
  //  [Tooltip("Our level timer in Seconds")]
    [SerializeField] float levelTimeInSeconds = 10; //Specificate times in seconds
    bool triggeredLevelFinished = false;

    private void Update()
    {
        if (triggeredLevelFinished) { return; } 
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimeInSeconds; //เวลาตั้งแต่เริ่ม / เวลาที่ตั้งไว้

        var SliderValue = GetComponent<Slider>().maxValue;
        if (GetComponent<Slider>().value >= SliderValue)

        {

            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;  // ถ้าค่า slider > Slider value so triggeredLevelFinished = true
        }
    }
}
