using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSpace;
using TMPro;

public class SettingsManager : MonoBehaviour, ISettingsData
{
    private QualitySettings qualitySettings;

    // Resolution
    [SerializeField] private TextMeshProUGUI resUI;
    int currentResolutionIndex;
    private Resolution[] resolutions;
    private Resolution resolution;

    [SerializeField] private List<string> ChangedSettings = new List<string>();


    // Display Mode
    private FullScreenMode fullScreenMode;

    // In-Game UI Objects
    [SerializeField] private GameObject PauseScreen;

    // Main-Menu UI Objects
    

    private void Start()
    {
        //Load Default Settings
        DataManager.Instance.LoadSettings();

        resolutions = Screen.resolutions;
        currentResolutionIndex = GetCurrentResolutionIndex();
        UpdateResolutionText();
    }

    public void Test_These_Please(string name, string hi)
    {

    }
    public void settingChanges(string setting)
    {
        ChangedSettings.Add(setting);
        Debug.Log($"{setting} changed!");
    }

    public void cancelChanges()
    {
        ChangedSettings.Clear();
        Debug.Log("Setting Changes Cleared!");
    }

    public void applyChanges()
    {
        for (int i = 0; i < ChangedSettings.Count; i++)
        {
            switch (ChangedSettings[i])
            {

            }
        }
    }
    public void changeTab(string tab)
    {
        if (ChangedSettings.Count > 0)
        {
            Debug.Log("Still need to apply or cancel changes");
        }
    }

    public void ApplyVideoSettings()
    {
        for(int i = 0; i < ChangedSettings.Count; i++)
        {
            // change setting
        }
        ChangedSettings.Clear();
        Debug.Log("Settings applied!");
    }


    public void setBrightness()
    {

    }

    public void setDisplayMode()
    {

    }

    public void setVsync()
    {

    }

    public void setResolution()
    {

    }

    public void setRefreshRate()
    {

    }
    public void setFPS()
    {

    }

    public void setAntiAliasing()
    {

    }

    public void setTextureResolution()
    {

    }
    public void setShadows()
    {

    }

    private void UpdateResolutionText()
    {
        resUI.text = $"{Screen.currentResolution.width}x{Screen.currentResolution.height}";
    }

    int GetCurrentResolutionIndex()
    {
        return resolutions.Length;
    }

    public void setScreenBrightness(float brightness)
    {
        brightness = Mathf.Clamp01(brightness);
    }

    public void setAnisotropic()
    {

    }

    public void setAmbientOcclusion()
    {

    }

    public void setBloom()
    {

    }

    public void setFilmGrain()
    {

    }

    public void setChromaticAbberation()
    {

    }

    public void setDepthofField()
    {

    }

    public void ApplyDisplaySettings()
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

  // Video/Display
    // Brightness
    // Fullscreen / Display Mode
    // Vsync
    // Resolution - list at start
    // Anti-Aliasing
    // Fidelity FX Super Resolution
    // Texture Resolution
    // Shadows
    // Anisotropic
    // Ambient Occlusion
    // Bloom
    // Film Grain
    // Chromatic Aberration
    // Depth of Field
    // Refresh Rate - list at start
    // FPS Limit - list at start
    // Gamma?

    // LOD?
  // Game
    // Sensitivity
    // Field of View/Vision
    // Keybinds (Toggles/Holds)
}
