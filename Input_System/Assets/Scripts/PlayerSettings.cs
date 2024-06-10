using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerSettings : MonoBehaviour
{
    public UniversalRenderPipelineAsset URPAsset;

    public void ScreenMode()
    {

    }

    public void HDR()
    {
        URPAsset.supportsHDR = false;
    }

}
