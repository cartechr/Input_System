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
    public Volume volume;
    public TextMeshProUGUI resUI;
    public TextMeshProUGUI counter;
    public Button Left;
    public Button Right;
    int Current;

    public Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        // Print the resolutions
        foreach (var res in resolutions)
        {
            if (res.width == Screen.width && res.height == Screen.height)
            {
                Debug.Log("Found Current Resolution - " + res);
                Current = System.Array.IndexOf(resolutions, res);
                resUI.text = $"{resolutions[Current].width.ToString()} x {resolutions[Current].height.ToString()}";
                counter.text = Current.ToString();
                return;
            }

        }
    }

    public void LeftButton()
    {
        if (Current != 0) 
        {
            Current--;
            Debug.Log(resolutions[Current]);
            resUI.text = $"{resolutions[Current].width.ToString()} x {resolutions[Current].height.ToString()}";
            counter.text = Current.ToString();

            Screen.SetResolution(resolutions[Current].width, resolutions[Current].height, false);
        }
    }

    public void RightButton()
    {
        if (Current != resolutions.Length)
        {
            Current++;
            Debug.Log(resolutions[Current]);
            resUI.text = $"{resolutions[Current].width.ToString()} x {resolutions[Current].height.ToString()}";
            counter.text = Current.ToString();

            Screen.SetResolution(resolutions[Current].width, resolutions[Current].height, false);
        }
    }

}
