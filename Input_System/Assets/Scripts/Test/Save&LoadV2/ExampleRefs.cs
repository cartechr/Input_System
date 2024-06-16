using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSpace;
using JetBrains.Annotations;
public class ExampleRefs : MonoBehaviour, ISlotsData, ISettingsData
{
    private bool isFullScreen = true;

    private int testInt;
    public void LoadSettings(SettingsData data)
    {
        //Data in this script = Interface Data

        //Loads data from save
        isFullScreen = data.fullscreen;
        testInt = data.Int;
    }

    public void SaveSettings(SettingsData data)
    {
        //Interface Data = Script Data
        // Saves data into settings data
        data.fullscreen = isFullScreen;

        data.Int = testInt;
    }

    public void LoadSlot(SlotData data)
    {
        //Data in this script = Interface Data
    }

    public void SaveSlot(SlotData data)
    {
        //Interface Data = Script Data
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            testInt++;
            Debug.Log($"New Value - {testInt}");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            DataManager.Instance.SaveSettings();
        }
    }
}
