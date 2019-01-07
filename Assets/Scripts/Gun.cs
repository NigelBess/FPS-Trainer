using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject bulletPrefab;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            audio.Play();
            gm.LogShot();
            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
               hit.transform.gameObject.SendMessage("Shot",SendMessageOptions.DontRequireReceiver);
            }
            GameObject.Instantiate(bulletPrefab, transform.position + transform.forward * 10, transform.rotation);
        }
    }
}
