using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public int setTime = 0; 
    private int currentTime = 0;
    public bool isCountDown = false;

    private Coroutine lastRoutine = null;

    void Start()
    {
        StartTimer();
    }

    public Timer()
    {
        setTime = 0;
        currentTime = setTime;
        isCountDown = false;
    }

    public void SetTime(int t)
    {
        setTime = t;
        currentTime = setTime;
    }

    public string GetTime()
    {
        return (currentTime / 60).ToString("00") + ":" + (currentTime % 60).ToString("00");
    }

    public void AddTime(int aTime)
    {
        currentTime += aTime;
    }
    
    public void SubtractTime(int sTime)
    {
        currentTime -= sTime;
    }

    public void SetIsCountDown(bool b)
    {
        isCountDown = b;
    }

    public bool GetIsCountDown()
    {
        return isCountDown;
    }

    public void StartTimer()
    {
        lastRoutine = StartCoroutine(KeepTime());
    }

    public void StopTimer()
    {
        StopCoroutine(lastRoutine);
    }

    public void Reset()
    {
        StopTimer();
        currentTime = setTime;
        StartTimer();
    }

    public IEnumerator KeepTime()
    {
        while (!isCountDown || currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            if (isCountDown)
            {
                currentTime--;
            }
            else
            {
                currentTime++;
            }
        }
    }

}

