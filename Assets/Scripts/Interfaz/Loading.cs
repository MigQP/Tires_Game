using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Loading : MonoBehaviour
{

    /*LOAD SCREEN MANAGER*/

    public Image loading;
    public Text timeText;
    public int minutes;
    public int sec;
    int totalSeconds = 0;
    int TOTAL_SECONDS = 0;
    float fillamount;

    public LevelChangerScript theChanger;
    public AudioMixerSnapshot fdOut;
    public AudioSource alarmSound;


    void Start()
    {
        timeText.text = minutes + ":" + sec;
        if (minutes > 0)
            totalSeconds += minutes * 60;
        if (sec > 0)
            totalSeconds += sec;
        TOTAL_SECONDS = totalSeconds;
        StartCoroutine(second());
    }

    void Update()
    {
        if (sec == 0 && minutes == 0)
        {
            timeText.text = "Time's Up!";
            StopCoroutine(second());
            fdOut.TransitionTo(.4f);
            theChanger.FadeToLevel(3);
        }

        if (sec == 60)
        {
            timeText.text = minutes + ":" + "0";
        }

        if (minutes == 0 && sec == 30)
        {
            alarmSound.Play();
        }

    }
    IEnumerator second()
    {
        yield return new WaitForSeconds(1f);
        if (sec > 0)
            sec--;
        if (sec == 0 && minutes != 0)
        {
            sec = 60;
            minutes--;
        }
        timeText.text = minutes + ":" + sec;
       // fillLoading();
        StartCoroutine(second());
    }

    void fillLoading()
    {
        totalSeconds--;
        float fill = (float)totalSeconds / TOTAL_SECONDS;
        loading.fillAmount = fill;
    }
}
