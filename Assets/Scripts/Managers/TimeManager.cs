using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float seconds;
    private int minutes;
    private int hours;

    private Text timeText;

	// Use this for initialization
	void Start ()
    {
        timeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        updateTime();	
	}

    void updateTime()
    {
        seconds += Time.deltaTime;
        timeText.text = hours + ":" + minutes + ":" + (int)seconds;
        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }
        else if (minutes >= 60)
        {
            hours++;
            minutes = 0;
        }
    }
}
