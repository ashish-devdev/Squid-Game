using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public int hour;
    public int min;
    public int sec;
    private float totalTime;
    public bool pause;

    public TimeDisplayType timeDisplayType;
    public enum TimeDisplayType
    {
        min_sec,
        sec

    };

    public UnityEvent onTimerEnds;
    bool onTimerEndsCalled;

    private void OnEnable()
    {
        pause = true;
        onTimerEndsCalled = false;
        DisplayTimeAtStart();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (!pause)
        {
            totalTime = totalTime - Time.deltaTime;
        }
        if (totalTime <= 0)
        {
            totalTime = 0;
            if (onTimerEnds != null && !onTimerEndsCalled)
            {
                onTimerEnds.Invoke();
                onTimerEndsCalled = true;
            }

        }
        timerText.text = TimeSpan.FromSeconds(totalTime).ToString(GetEnumEquivalentString(timeDisplayType));
    }


    public void StartTimer()
    {

        totalTime = CovertTimeIntoTotalSec(hour, min, sec);
        timerText.text = TimeSpan.FromSeconds(totalTime).ToString(GetEnumEquivalentString(timeDisplayType));
        pause = false;

    }

    public void PauseTimer()
    {
        pause = true;
    }

    public void ResumeTimer()
    {
        pause = false;
    }

    private float CovertTimeIntoTotalSec(int hr, int min, int sec)
    {
        return ((hr * 60 * 60) + (min * 60) + sec);
    }


    public string GetEnumEquivalentString(TimeDisplayType timeDisplayType)
    {
        switch (timeDisplayType)
        {

            case TimeDisplayType.min_sec:
                return @"mm\:ss";

            case TimeDisplayType.sec:
                return @"ss";


        }

        return "";


    }
    public void DisplayTimeAtStart()
    {
        totalTime = CovertTimeIntoTotalSec(hour, min, sec);
        timerText.text = TimeSpan.FromSeconds(totalTime).ToString(GetEnumEquivalentString(timeDisplayType));
    }



}
