using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasManager cm;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject secondaryCam;
    [SerializeField] private Timer timer;
    [SerializeField] private Text killText;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text AccuracyText;
    [SerializeField] private DataLogger dl;
    [SerializeField] private string fileName = "scores";
    [SerializeField] private string highScoreFileName = "highScore";
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text welcomeHighScoreText;
    private DateTime startDate = new DateTime(2019,1,1);
    private int hits;
    private int shots;
    private int kills;

    private void Awake()
    {
        cm.Welcome();
        StartGame(false);
        welcomeHighScoreText.text = "High Score: " + GetHighScore().ToString();
    }
    public void StartGame(bool state)
    {
        if (state)
        {
            cm.HUD();
            timer.StartGame();
            killText.text = "0";
            kills = 0;
            hits = 0;
            shots = 0;
        }
        player.SetActive(state);
        secondaryCam.SetActive(!state);
    }
    public void Resume()
    {
        cm.HUD();
        timer.UnPause();
        player.SetActive(true);
        secondaryCam.SetActive(false);
    }
    public void Pause()
    {
        StartGame(false);
        cm.Pause();
        timer.Pause();
    }
    public void LogHit()
    {
        hits++;
    }
    public void LogShot()
    {
        shots++;
    }
    public void LogKill()
    {
        kills++;
        killText.text = kills.ToString();
    }
    public void EndGame()
    {
        StartGame(false);
        cm.Results();
        float accuracy = (float)hits / (float)shots * 100;
        ScoreText.text = "Score: " + kills.ToString();
        AccuracyText.text = "Accuracy: " + accuracy.ToString("F2") + "%";
        LogGame();
    }
    void LogGame()
    {
        float accuracy = (float)hits / (float)shots * 100;
        int day = (int)(DateTime.Today - startDate).TotalDays; 
        string data = kills.ToString() + ", " + accuracy.ToString("F3") + ", " + day.ToString();

       dl.Save(fileName,data,true);
        int highScore = GetHighScore();
        highScoreText.text = "";
        if (kills > highScore)
        {
            highScoreText.text = "High Score!";
            dl.Save(highScoreFileName,kills.ToString(),false);
        }
    }
    public void Restart()
    {
        
        SceneManager.LoadScene("Play");
        cm.Welcome();
    }
    private int GetHighScore()
    {
        int highScore;
        try
        {
            highScore = int.Parse(dl.Read(highScoreFileName));
        }
        catch
        {
            highScore = 0;
        }
        return highScore;
    }
}
