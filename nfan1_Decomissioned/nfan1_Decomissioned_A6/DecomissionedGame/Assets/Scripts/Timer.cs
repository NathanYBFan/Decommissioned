using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 10f;
    public bool timerIsSet = false;
    [SerializeField] public TMP_Text timerText;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime (float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float miliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:000}", seconds, miliseconds);
    }
}
