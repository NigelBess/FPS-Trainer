using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTarget : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    private void Awake()
    {
       Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Camera.main.transform.forward * speed;
        StartCoroutine(WaitThenDie());

    }
    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(transform.gameObject);
    }
}
