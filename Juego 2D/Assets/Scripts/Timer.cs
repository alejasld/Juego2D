using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerMinutes;
    public TextMeshProUGUI timerSeconds;
    public TextMeshProUGUI timerSeconds100;

    private float startTime;
    private float stopTime;
    private float timerTime;
    private bool isRunning = false;

    void Start()
    {
        TimerStart();
    }

    public void TimerStart()
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
        }
    }

    public void TimerStop()
    {
        if (isRunning)
        {
            isRunning = false;
            stopTime = timerTime;
        }
    }

    public void TimerReset()
    {
        stopTime = 0;
        isRunning = false;
        timerMinutes.text = timerSeconds.text = timerSeconds100.text = "00";
    }

    void Update()
    {
        if (isRunning)
        {
            timerTime = stopTime + (Time.time - startTime);

            int minutesInt = (int)timerTime / 60;
            int secondsInt = (int)timerTime % 60;
            int seconds100Int = (int)((timerTime - (secondsInt + minutesInt * 60)) * 100);

            timerMinutes.text = minutesInt.ToString("00");
            timerSeconds.text = secondsInt.ToString("00");
            timerSeconds100.text = seconds100Int.ToString("00");
        }
    }

    public float StopTime { get => stopTime; }
    public float TimerTime { get => timerTime; }
}
