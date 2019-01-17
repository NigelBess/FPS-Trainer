using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    private float vy;
    private float vx;
    [SerializeField] private GameSettings settings;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform player;
    [SerializeField] private float zeta = 0.7f;//defines motion profile
    [SerializeField] private float deltaPercent = 37;//resting height relative to recoil height
    [SerializeField] private float period = 0.560f;//time in s over which recoil takes place
    [SerializeField] private float estimationConstant = 3.4f;//this simulation uses a rough estimation to calculate friction losses. 3.4 works well here
    private float k = 100;//arbitrary but needed for calculations. changing this does nothing
    // but  having it as a variable makes the math more legible in the code
    private float m;
    private float c;
    private float f;
    private float y;

    private void Awake()
    {
        vy = 0;
        vx = 0;
        y = 0;
        float wd = 2f * 3.14f / period;
        float wn = wd / Mathf.Sqrt(1 - Mathf.Pow(zeta, 2));
        m = k / (Mathf.Pow(wn, 2));
        float cc = Mathf.Sqrt(4 * m * k);
        c = zeta * cc;
    }
    public void Fire()
    {
        y = 0;
        float height = Random.Range(settings.minRecoil, settings.maxRecoil);
        float vAverage = estimationConstant * zeta * height / period;
        f = k * height * deltaPercent / 100;
        vy = Mathf.Sqrt(height * (k * height + 2 * c * vAverage - 2 * f) / m);
        vx = Random.Range(-settings.maxSideRecoil, settings.maxSideRecoil);
        StartCoroutine(EndRecoil());
    }
    private void Update()
    {
        if (vy != 0 && vx != 0)
        {
            float dy = vy * Time.deltaTime;
            float dx = vx * Time.deltaTime;
            vy = vy + DeltaV()*Time.deltaTime;
            y = y + dy;
            float yRot = cam.localRotation.eulerAngles.x;
            yRot = yRot - dy;
            Debug.Log(yRot);
            cam.localRotation = Quaternion.Euler(yRot,0,0);
            player.rotation = Quaternion.Euler(0, player.rotation.eulerAngles.y + dx, 0);
        }
    }
    private float DeltaV()
    {
        return (-c * vy - k * y + f) / m;
    }
    IEnumerator EndRecoil()
    {
        yield return new WaitForSeconds(period);
        vy = 0;
        vx = 0;
    }
}
