using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
 
    private void Update()
    {
        transform.LookAt(transform.position + rb.velocity);
    }
}
