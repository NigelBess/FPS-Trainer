using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject[] canvases;

    public void Welcome()
    {
        OpenCanvas(0);
    }
    public void HUD()
    {
        OpenCanvas(1);
    }
    public void Pause()
    {
        OpenCanvas(2);
    }
    public void Results()
    {
        OpenCanvas(3);
    }
    public void Settings()
    {
        OpenCanvas(4);
    }

    private void OpenCanvas(int num)
    {
        GameFunctions.OpenMenu(canvases, num);
    }
    
}
