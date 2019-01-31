using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    [SerializeField] private InputField iField;
    [SerializeField] private DataLogger dl;
    [SerializeField] private string fileName = "sense";
    [SerializeField] private GameSettings settings;
    private float sense;
    private void Awake()
    {
        try
        {
            sense = float.Parse(dl.Read(fileName));
        }
        catch
        {
            sense = 1.0f;
            dl.Save(fileName,sense.ToString(),false);
        }
        iField.text = sense.ToString();

    }
    public void SetSense()
    {
        try
        {
            sense = float.Parse(iField.text);
        }
        catch
        {
        }
        dl.Save(fileName, sense.ToString(), false);
       settings.sensitivity = sense;
    }
}
