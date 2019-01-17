﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject dropBulletPrefab;
    [SerializeField] private float bulletStartDistance = 9;
    [SerializeField] private Recoil recoil;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            audio.Play();
            gm.LogShot();
            if (settings.recoil)
            {
                recoil.Fire();
            }


            if (settings.drop)
            {
                GameObject.Instantiate(dropBulletPrefab, transform.position + transform.forward * bulletStartDistance, transform.rotation);
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    hit.transform.gameObject.SendMessage("Shot", SendMessageOptions.DontRequireReceiver);
                }
                GameObject.Instantiate(bulletPrefab, transform.position + transform.forward * bulletStartDistance, transform.rotation);
            }
            
        }
    }
}
