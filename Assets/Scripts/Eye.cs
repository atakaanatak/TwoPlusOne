using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public float time;
    private float defaultTime;
    private bool timerRunning;
    public static Action OnTimeRunOut;
    public float breathSpeed = 2f;
    public float maxScale = 1.5f;
    public float minScale = 1f;

    private bool isTimerActive;
    private bool isTimerPaused;
    public TextMeshProUGUI countDownText;

    private float breathTimer; 

    private void Start()
    {
        defaultTime = time;
        PopUpDamageScreen.DamageOn += PauseTimer;
        PopUpDamageScreen.DamageOff += ResumeTimer;
        breathTimer = 0f; 
    }

    private void OnDestroy()
    {
        PopUpDamageScreen.DamageOn -= PauseTimer;
        PopUpDamageScreen.DamageOff -= ResumeTimer;
    }

    private void ResumeTimer()
    {
      
        if (timerRunning)
        {
            Debug.Log("Timer Resumed");
            isTimerPaused = false;
            StartCountDown();
        }
    }

    private void PauseTimer()
    {
      
        if (timerRunning)
        {
            Debug.Log("Timer Paused");
            isTimerPaused = true;
            StopCoroutine(TimerCountdown());
        }
    }

    public void StartCountDown()
    {
        timerRunning = true;
        StartCoroutine(TimerCountdown());
        StartCoroutine(BreathingCoroutine());
    }

    private IEnumerator TimerCountdown()
    {
        time = defaultTime;
        while (time > 0f && timerRunning && !isTimerPaused)
        {
            time -= Time.deltaTime;
            countDownText.text = $"{time:F2}";
            yield return null;
        }

        if (time <= 0 && timerRunning && !isTimerPaused)
        {
            Debug.Log("Time is up!");
            StopCoroutine(TimerCountdown());
            StopCoroutine(BreathingCoroutine());
            OnTimeRunOut?.Invoke();
           
        }
    }

    private IEnumerator BreathingCoroutine()
    {
        breathTimer = 0f;
        while (timerRunning&& !isTimerPaused)
        {
            breathTimer += Time.deltaTime * breathSpeed;
            
            float pingPongValue = Mathf.PingPong(breathTimer, 1f);
            
            float scale = Mathf.Lerp(minScale, maxScale, pingPongValue);
            countDownText.transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

       
    }

    public void StopCountDown()
    {
        timerRunning = false;
        StopCoroutine(TimerCountdown());
        StopCoroutine(BreathingCoroutine());
        time = defaultTime;
        breathTimer = 0f;
        countDownText.text = $"{time:F2}";
    }
}
