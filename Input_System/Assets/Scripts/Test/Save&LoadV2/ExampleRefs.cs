using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSpace;
using JetBrains.Annotations;
public class ExampleRefs : MonoBehaviour, ISlotsData, ISettingsData
{
    private bool isFullScreen = true;
    public void LoadSettings(SettingsData data)
    {
        //Data in this script = Interface Data

        //Loads data from save
        isFullScreen = data.fullscreen;
    }

    public void SaveSettings(SettingsData data)
    {
        //Interface Data = Script Data
        // Saves data into settings data
        data.fullscreen = isFullScreen;
    }

    public void LoadSlot(SlotData data)
    {
        //Data in this script = Interface Data
    }

    public void SaveSlot(SlotData data)
    {
        //Interface Data = Script Data
    }
}
