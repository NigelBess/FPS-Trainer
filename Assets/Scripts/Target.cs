using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private AudioSource ping;
    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject deadPrefab;
    [SerializeField] private GameManager gm;
    [SerializeField] private float maxDistance = 20;
    [SerializeField] private float minDistance = 1;
    private Vector3 originPoint;
    [SerializeField] private float maxSpeed = 7;
    [SerializeField] private float minSpeed = 4;
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
        setHP(3);
        float dist = Random.Range(minDistance,maxDistance);
        float angle = Random.Range(0, 360);
        float x = dist * Mathf.Cos(angle);
        float y = dist * Mathf.Sin(angle);
        transform.position = originPoint + new Vector3(x, y, 0);
        float speed = Random.Range(minSpeed, maxSpeed);
        float coinToss = Random.Range(0, 1);
        if (coinToss > 0.5) speed = - speed;
        SetSpeed(speed);
    }
    private void SetSpeed(float val)
    {
        currentSpeed = Mathf.Abs(val);
        rb.velocity = (originPoint - transform.position).normalized * val;
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
        if (Vector3.SqrMagnitude(originPoint - transform.position) > (Mathf.Pow(maxDistance,2)))
        {
            SetSpeed(currentSpeed);
        }
    }
}
