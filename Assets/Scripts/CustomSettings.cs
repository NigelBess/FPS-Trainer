using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomSettings : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private Toggle dropToggle;
    [SerializeField] private Toggle recoilToggle;
    [SerializeField] private Toggle senseToggle;
    [SerializeField] private Toggle autoToggle;
    [SerializeField] private InputField healthField;
    [SerializeField] private InputField rateField;
    [SerializeField] private DataLogger dl;
    [SerializeField] private string fileName = "CustomSettings";
    private void Awake()
    {
        string[] settingsString = dl.ReadArray(fileName);        
        try
        {
            dropToggle.isOn = bool.Parse(settingsString[0]);
            recoilToggle.isOn = bool.Parse(settingsString[1]);
            senseToggle.isOn = bool.Parse(settingsString[2]);
            healthField.text = settingsString[3];   
            autoToggle.isOn = bool.Parse(settingsString[4]);
            rateField.text = settingsString[5];
        }
        catch
        {
            dropToggle.isOn = false;
            recoilToggle.isOn = false;
            senseToggle.isOn = false;
            healthField.text = "3";
            autoToggle.isOn = false;
            rateField.text = "18";
        }
    }
    public void SetSettings()
    {
        settings.drop = dropToggle.isOn;
        settings.recoil = recoilToggle.isOn;
        settings.senseChange = senseToggle.isOn;
        settings.fullAuto = autoToggle.isOn;
        int health;
        int rof;
        try
        {
            health = int.Parse(healthField.text);
            rof = int.Parse(rateField.text);
        }
        catch
        {
            health = 3;
            rof = 18;
        }
        settings.maxHealth = health;
        settings.rateOfFire = rof;
        Save();
    }
    private void Save()
    {
        dl.Save(fileName, settings.drop.ToString() + ",",false);
        dl.Save(fileName, settings.recoil.ToString() + ",", true);
        dl.Save(fileName, settings.senseChange.ToString() + ",", true);
        dl.Save(fileName, settings.maxHealth.ToString() + ",", true);
        dl.Save(fileName, settings.fullAuto.ToString() + ",", true);
        dl.Save(fileName, settings.rateOfFire.ToString() + ",", true);
    }

}
