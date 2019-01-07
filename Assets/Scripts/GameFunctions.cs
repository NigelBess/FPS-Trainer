using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameFunctions
{
    public static void OpenMenu(GameObject[] menus,int num)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == num);
        }
    }
}
