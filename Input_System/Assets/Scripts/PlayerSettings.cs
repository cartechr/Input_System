using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class PlayerSettings : MonoBehaviour
{
    public TextMeshProUGUI resUI;
    int currentResolutionIndex;
    public Resolution[] resolutions;

    private void Start()
    {
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
}