using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceClick : MonoBehaviour
{
    private Button b;
    private void Awake()
    {
        b = GetComponent<Button>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            b.onClick.Invoke();
        }
    }
}
