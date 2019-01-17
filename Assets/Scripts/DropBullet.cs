using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBullet : Bullet
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        collision.transform.gameObject.SendMessage("Shot", SendMessageOptions.DontRequireReceiver);
    }
}
