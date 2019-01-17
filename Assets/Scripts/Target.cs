using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private AudioSource ping;
    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject deadPrefab;
    [SerializeField] private GameManager gm;
    [SerializeField] private FPSAimer aimer;
    
    private Vector3 originPoint;
    private float currentZ;
    
    private Rigidbody rb;
    private MeshRenderer rend;
    private int hp;
    private float currentSpeed;
    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        originPoint = transform.position;
        Refresh();
    }
    public void Refresh()
    {
        float sense = settings.sensitivity;
        if (settings.senseChange)
        {
            sense = sense + Random.Range(-settings.deltaSensePercent, settings.deltaSensePercent) * sense / 100;
        }
        aimer.SetSense(sense);

        setHP(3);
        float dist = Random.Range(settings.minDistance,settings.maxDistance);
        float angle = Random.Range(0, 360);
        float x = dist * Mathf.Cos(angle);
        float y = dist * Mathf.Sin(angle);
        currentZ = 0;
        if (settings.drop)
        {
            currentZ = Random.Range(settings.minRange, settings.maxRange);
        }
        transform.position = originPoint + new Vector3(x, y, currentZ);
        float speed = Random.Range(settings.minSpeed, settings.maxSpeed);
        float coinToss = Random.Range(0f, 1f);
        if (coinToss > 0.5) speed = - speed;
        SetSpeed(speed);
    }
    private void SetSpeed(float val)
    {
        currentSpeed = Mathf.Abs(val);
        rb.velocity = (alteredOrigin() - transform.position).normalized * val;
    }
    private void Shot()
    {
        gm.LogHit();
        setHP(hp-1);
        if (hp > 0)
        {
            ping.Play();
        }
        else
        {
            gm.LogKill();
            GameObject.Instantiate(deadPrefab,transform.position,transform.rotation);
            Refresh();
        }
    }

    private void setHP(int val)
    {
        hp = val;
        if (val > 0)
        {
            rend.material = materials[val - 1];
        }
        
    }
    private void Update()
    {
        if (Vector3.SqrMagnitude(alteredOrigin() - transform.position) > (Mathf.Pow(settings.maxDistance,2)))
        {
            SetSpeed(currentSpeed);
        }
    }
    private Vector3 alteredOrigin()
    {
        return originPoint + new Vector3(0, 0, currentZ);
    }
}
