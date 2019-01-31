using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSAimer : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1;
    [SerializeField] private Transform cam;

    private void OnEnable()
    {
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.visible = true;
    }

    void Update ()
    {
        float rotX = Input.GetAxis("Mouse X") * sensitivity;
        float rotY = -Input.GetAxis("Mouse Y") * sensitivity;
        transform.Rotate(0, rotX, 0);
        cam.Rotate(rotY, 0, 0);
        float yRot = cam.localRotation.eulerAngles.x;
        yRot -= Mathf.Floor(yRot / 360) * 360;
        if (yRot > 180)
        {
            yRot -= 360;
        }

        yRot = Mathf.Clamp(yRot, -90, 90);
        cam.localRotation = Quaternion.Euler(yRot, 0,0);
    }
    public void SetSense(float sense)
    {
        sensitivity = sense;
    }
}
