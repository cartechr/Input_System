using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessin : MonoBehaviour
{
    [SerializeField] UniversalRenderPipelineAsset URPAsset;

    public bool isBloom;
    public bool isChannelMixer;
    public bool isChromaticAbberation;
    public bool isColorAdjustments;
    public bool isColorCurves;
    public bool isDepthOfField;
    public bool isDepthOffieldModeParameter;
    public bool isFilmGrain;
    public bool isFilmGrainLookupParameter;


    [HideInInspector] public bool isTest;
    [HideInInspector] public float isFloat;
    [HideInInspector] public string isString;

    [Space(50)]
    [Header("Bloom")]
    public MinFloatParameter clamp;
    public MinFloatParameter dirIntensity;
    public TextureParameter dirTexture;
    public BoolParameter highQualityFiltering;
    public MinFloatParameter intensity;
    public ClampedFloatParameter scatter = new ClampedFloatParameter(0, 0, 10);
    public MinFloatParameter threshold;
    public ColorParameter tint;

    public bool IsActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Button Pressed");

            //HDR();
            //AntiAliasing();
            clamp.value = isFloat;

            //dirTexture.dimension;
            

            

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

