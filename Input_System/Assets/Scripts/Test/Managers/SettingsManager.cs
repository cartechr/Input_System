using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSpace;
using TMPro;

public class SettingsManager : MonoBehaviour, ISettingsData
{
    [SerializeField] private TextMeshProUGUI resUI;
    int currentResolutionIndex;
    private Resolution[] resolutions;
    private Resolution resolution;
    private FullScreenMode fullScreenMode;


    private void Start()
    {
        DataManager.Instance.LoadSettings();

        resolutions = Screen.resolutions;
        currentResolutionIndex = GetCurrentResolutionIndex();
        UpdateResolutionText();
    }

    private void UpdateResolutionText()
    {
        resUI.text = $"{Screen.currentResolution.width}x{Screen.currentResolution.height}";
    }

    int GetCurrentResolutionIndex()
    {
        return resolutions.Length;
    }

    public void SetScreenBrightness(float brightness)
    {
        brightness = Mathf.Clamp01(brightness);
    }

    public void SetScreenMode()
    {

    }

    public void LoadSettings(SettingsData data)
    {
        fullScreenMode = data.fullscreenMode;
        //resolutions
    }

    public void SaveSettings(SettingsData data)
    {

    }
}
