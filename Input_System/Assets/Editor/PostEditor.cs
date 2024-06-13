using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;

#if UNITY_EDITOR
[CustomEditor(typeof(PostProcessin))]
public class PostEditor : Editor
{
    private Vector2 scrollPos;
    AnimBool animBool;


    private bool isIntensity;
    private bool isScatter;
    private bool isTint;
    private bool isClamp;
    private bool isHigh;

    private bool isDirtTexture;

    private bool isChannelMixer;
    private bool isChromaticAbberation;
    private bool isColorAdjustments;
    private bool isColorCurves;
    private bool isDepthOfField;
    private bool isDepthOffieldModeParameter;
    private bool isFilmGrain;
    private bool isFilmGrainLookupParameter;
    private bool isLensDistortion;
    private bool isLiftGammaGain;
    private bool isMotionBlur;

    void OnEnable()
    {
        animBool = new AnimBool(true);
        animBool.valueChanged.AddListener(Repaint);
    }
    public override void OnInspectorGUI()
    {
        // Get the target object (the MyComponent instance)
        PostProcessin postProcessin = (PostProcessin)target;

        // Set the width of the scroll view
        float scrollViewWidth = EditorGUIUtility.currentViewWidth - 30; // Adjust as needed
        float contentWidth = scrollViewWidth + 200; // Make content wider to force horizontal scrollbar


        // Begin a scroll view with fixed dimensions
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(scrollViewWidth), GUILayout.Height(1000));

        // Draw the default inspector
        DrawDefaultInspector();

        EditorGUILayout.Space(15);
        animBool.target = EditorGUILayout.ToggleLeft("Post Processing", animBool.target);
        if (EditorGUILayout.BeginFadeGroup(animBool.faded))
        {
            #region Bloom Editor
            EditorGUI.indentLevel++;

            EditorGUILayout.BeginHorizontal(GUI.skin.box, GUILayout.Height(20));
            {
                postProcessin.isBloom = EditorGUILayout.Foldout(postProcessin.isBloom, GUIContent.none);
                EditorGUI.indentLevel--;
                EditorGUI.indentLevel--;
                EditorGUI.indentLevel--;
                postProcessin.isBloom = EditorGUILayout.ToggleLeft("Bloom", postProcessin.isBloom, GUILayout.Width(scrollViewWidth - 85));
                EditorGUI.indentLevel++;
                EditorGUI.indentLevel++;
                EditorGUI.indentLevel++;
            }
            EditorGUILayout.EndHorizontal();


            if (postProcessin.isBloom)
            {

                EditorGUI.indentLevel++;
                EditorGUI.indentLevel++;

                EditorGUILayout.BeginHorizontal();
                isClamp = EditorGUILayout.BeginToggleGroup("Clamp", isClamp);
                {
                    postProcessin.clamp.value = EditorGUILayout.FloatField(postProcessin.clamp.value);
                }
                EditorGUILayout.EndToggleGroup();
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                isIntensity = EditorGUILayout.BeginToggleGroup("Dir Intensity", isIntensity);
                {
                    postProcessin.dirIntensity.value = EditorGUILayout.FloatField(postProcessin.dirIntensity.value);
                }
                EditorGUILayout.EndToggleGroup();
                EditorGUILayout.EndHorizontal();

                postProcessin.highQualityFiltering.value = EditorGUILayout.Toggle("High Quality Filtering", postProcessin.highQualityFiltering.value);
            }

            postProcessin.intensity.value = EditorGUILayout.FloatField("Intensity", postProcessin.intensity.value);
            postProcessin.scatter.value = EditorGUILayout.FloatField("Scatter", postProcessin.scatter.value);
            postProcessin.threshold.value = EditorGUILayout.FloatField("Threshold", postProcessin.threshold.value);
            postProcessin.tint.value = EditorGUILayout.ColorField("Tint", postProcessin.tint.value);
            if (postProcessin.isLensDirt)
            {
                postProcessin.dirTexture.value = (Texture)EditorGUILayout.ObjectField("Dir Texture", postProcessin.dirTexture.value, typeof(Texture), false);
                //postProcessin.dirTexture.dimension = EditorGUILayout.Popup("Dir Texture Dimension", postProcessin.dirTexture.dimension);

            }

                EditorGUI.indentLevel--;
                EditorGUI.indentLevel--;
                EditorGUI.indentLevel--;

            #endregion

            #region Channel Mixer
            isChannelMixer = EditorGUILayout.BeginToggleGroup("Channel Mixer", isChannelMixer);
            {
                postProcessin.blueOutBlueIn.value = EditorGUILayout.FloatField("blueOutBlueIn", postProcessin.blueOutBlueIn.value);
                postProcessin.blueOutGreenIn.value = EditorGUILayout.FloatField("blueOutGreenIn", postProcessin.blueOutGreenIn.value);
                postProcessin.blueOutRedIn.value = EditorGUILayout.FloatField("blueOutRedIn", postProcessin.blueOutRedIn.value);
                postProcessin.greenOutBlueIn.value = EditorGUILayout.FloatField("greenOutBlueIn", postProcessin.greenOutBlueIn.value);
                postProcessin.greenOutGreenIn.value = EditorGUILayout.FloatField("greenOutGreenIn", postProcessin.greenOutGreenIn.value);
                postProcessin.greenOutRedIn.value = EditorGUILayout.FloatField("greenOutRedIn", postProcessin.greenOutRedIn.value);
                postProcessin.redOutBlueIn.value = EditorGUILayout.FloatField("redOutBlueIn", postProcessin.redOutBlueIn.value);
                postProcessin.redOutGreenIn.value = EditorGUILayout.FloatField("redOutGreenIn", postProcessin.redOutGreenIn.value);
                postProcessin.redOutRedIn.value = EditorGUILayout.FloatField("redOutRedIn", postProcessin.redOutRedIn.value);
            }

            EditorGUILayout.EndToggleGroup();

            #endregion

            #region Chromatic Abberation
            isChromaticAbberation = EditorGUILayout.BeginToggleGroup("ChromaticAberration", isChromaticAbberation);
            {
                postProcessin.chrom_intensity.value = EditorGUILayout.FloatField("Intensity", postProcessin.chrom_intensity.value);
            }

            EditorGUILayout.EndToggleGroup();

            #endregion

            #region Color Adjustments
            isColorAdjustments = EditorGUILayout.BeginToggleGroup("Color Adjustments", isColorAdjustments);
            {
                postProcessin.colorFilter.value = EditorGUILayout.ColorField("colorFilter", postProcessin.colorFilter.value);
                postProcessin.contrast.value = EditorGUILayout.FloatField("Contrast", postProcessin.contrast.value);
                postProcessin.hueShift.value = EditorGUILayout.FloatField("Hue Shift", postProcessin.hueShift.value);
                postProcessin.postExposure.value = EditorGUILayout.FloatField("Post Exposure", postProcessin.postExposure.value);
                postProcessin.saturation.value = EditorGUILayout.FloatField("Saturation", postProcessin.saturation.value);
            }

            EditorGUILayout.EndToggleGroup();

            #endregion

            #region Color Curves
            isColorCurves = EditorGUILayout.BeginToggleGroup("Color Curves", isColorCurves);
            {

            }

            EditorGUILayout.EndToggleGroup();

            #endregion
        }


        EditorGUILayout.EndFadeGroup();

        EditorGUILayout.EndScrollView();

        // Save any changes to the object
        if (GUI.changed)
        {
            EditorUtility.SetDirty(postProcessin);
        }
    }
}

#endif
