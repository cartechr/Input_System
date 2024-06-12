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
    private Gradient gradient;
    AnimBool animBool;

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
            postProcessin.isBloom = EditorGUILayout.BeginToggleGroup("Bloom", postProcessin.isBloom);
            {
                postProcessin.clamp.value = EditorGUILayout.FloatField("Clamp", postProcessin.clamp.value);
                postProcessin.dirIntensity.value = EditorGUILayout.FloatField("Dir Intensity", postProcessin.dirIntensity.value);
                postProcessin.dirTexture.value = (Texture)EditorGUILayout.ObjectField("Dir Texture", postProcessin.dirTexture.value, typeof(Texture), false);
                //postProcessin.dirTexture.dimension = EditorGUILayout.Popup("Dir Texture Dimension", postProcessin.dirTexture.dimension);
                postProcessin.highQualityFiltering.value = EditorGUILayout.Toggle("High Quality Filtering",postProcessin.highQualityFiltering.value);
                postProcessin.intensity.value = EditorGUILayout.FloatField("Intensity", postProcessin.intensity.value);
                postProcessin.scatter.value = EditorGUILayout.FloatField("Scatter", postProcessin.scatter.value);
                postProcessin.threshold.value = EditorGUILayout.FloatField("Threshold", postProcessin.threshold.value);
                postProcessin.tint.value = EditorGUILayout.ColorField("Tint", postProcessin.tint.value);
            }
                EditorGUILayout.EndToggleGroup();

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
