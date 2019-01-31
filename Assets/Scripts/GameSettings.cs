using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public float sensitivity;
    public bool fullAuto = false;
    public int rateOfFire = 18;
    public bool recoil = false;
    public bool senseChange = false;
    public bool drop = false;
    public float maxDistance = 20;
    public float minDistance = 1;
    public float maxSpeed = 7;
    public float minSpeed = 4;
    public float maxRange = 100;
    public float minRange = 0;
    public float deltaSensePercent = 50;
    public float maxRecoil = 5;//degrees
    public float minRecoil = 2;//degrees
    public float maxSideRecoil = 2;//degrees
    public int maxHealth = 3;
    public GameMode mode;
    public enum GameMode
   {
        normal,
        insane,
        custom,
   }
}
