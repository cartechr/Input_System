using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessin : MonoBehaviour
{
    [SerializeField] UniversalRenderPipelineAsset URPAsset;


    [HideInInspector] public bool isTest;
    [HideInInspector] public float isFloat;
    [HideInInspector] public string isString;

    public bool isBloom;
    public bool isLensDirt;

    [Space(25)]
    [Header("Bloom")]
    public MinFloatParameter clamp;
    public MinFloatParameter dirIntensity;
    public TextureParameter dirTexture;
    public BoolParameter highQualityFiltering;
    public MinFloatParameter intensity;
    public ClampedFloatParameter scatter = new ClampedFloatParameter(0, 0, 10);
    public MinFloatParameter threshold;
    public ColorParameter tint;

    [Space(5)]
    [Header("Channel Mixer")]
    public ClampedFloatParameter blueOutBlueIn = new ClampedFloatParameter(0, 0, 10);
    public ClampedFloatParameter blueOutGreenIn = new ClampedFloatParameter(0, 0, 10);
    public ClampedFloatParameter blueOutRedIn = new ClampedFloatParameter(0, 0, 10);
    public ClampedFloatParameter greenOutBlueIn = new ClampedFloatParameter(0, 0, 10);
    public ClampedFloatParameter greenOutGreenIn = new ClampedFloatParameter(0, 0, 10);
    public ClampedFloatParameter greenOutRedIn = new ClampedFloatParameter(0, 0, 10);
    public ClampedFloatParameter redOutBlueIn = new ClampedFloatParameter(0, 0, 10);
    public ClampedFloatParameter redOutGreenIn = new ClampedFloatParameter(0, 0, 10);
    public ClampedFloatParameter redOutRedIn = new ClampedFloatParameter(0, 0, 10);

    [Space (5)]
    [Header("Chromatic Aberration")]
    public ClampedFloatParameter chrom_intensity = new ClampedFloatParameter (0, 0, 10);

    [Space(5)]
    [Header("Color Adjustments")]
    public ColorParameter colorFilter;
    public ClampedFloatParameter contrast = new ClampedFloatParameter(0, 0, 10);
    public ClampedFloatParameter hueShift = new ClampedFloatParameter(0, 0, 10);
    public FloatParameter postExposure;
    public ClampedFloatParameter saturation = new ClampedFloatParameter(0, 0, 10);

    [Space(5)]
    [Header("Color Curves")]
    public TextureCurveParameter blue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Button Pressed");

            //HDR();
            //AntiAliasing();
            //clamp.value = isFloat;

            //dirTexture.dimension;
            
            Debug.Log(blue.value);

            

        }
    }
}










//DepthOfField
//Bloom
//FilmGrain
//LensDistortion
//MotionBlur
//ChromaticAberration
//ShadowQuality
//ShadowResolution

