using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private UniversalRenderPipelineAsset URPAsset;


    public void ScreenMode()
    {

    }

    public void HDR(bool hdr)
    {
        URPAsset.supportsHDR = hdr;
    }

    public void AntiAliasing(int aliasing)
    {
        URPAsset.msaaSampleCount = aliasing;
    }
 


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Button Pressed");
            
            //HDR();
            //AntiAliasing();

        }
    }

}
