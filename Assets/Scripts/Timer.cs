
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private GameManager gm;
    [SerializeField] private float maxTime = 60;
    private float remainingTime;
    private float startTime;
    private void Awake()
    {
        enabled = false;
    }
    public void StartGame()
    {
        startTime = Time.time;
        enabled = true;
    }
    private void Update()
    {
        remainingTime = (maxTime + startTime - Time.time);
        if (remainingTime <= 0)
        {
            gm.EndGame();
            enabled = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            gm.Pause();
        }
        //TimeSpan t = TimeSpan.FromSeconds(remainingTime);
        timerText.text = Mathf.Floor(remainingTime/60).ToString()+":"+((int)remainingTime-Mathf.Floor(remainingTime/60)*60).ToString();
    }
    public void Pause()
    {
        enabled = false;
    }
    public void UnPause()
    {
        enabled = true;
        startTime = Time.time - (maxTime - remainingTime);
    }

}
