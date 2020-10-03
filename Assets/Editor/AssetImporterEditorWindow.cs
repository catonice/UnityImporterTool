using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEditor.Presets;

class AssetImporterEditorWindow : EditorWindow
{
    Vector2 scrollPos;

    bool overrideTexturesForAndroid = true;
    bool overrideAudioForAndroid = true;
    float maxTextureSize = 0;
    float mipMapLevel = 0;

    float androidMaxTextureSize = 0;
    float androidMipMapLevel = 0;
    //Preset preset = null;

    int selected = 0;
    string[] options = new string[]
    {
     "Option1", "Option2", "Option3",
    };

    [MenuItem("Window/Custom Asset Importer Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(AssetImporterEditorWindow));
    }
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(500));
        //preset = (Preset)EditorGUILayout.ObjectField("Preset", preset, typeof(Preset), true);

        GUILayout.Label("Texture Settings", EditorStyles.boldLabel);
        maxTextureSize = EditorGUILayout.Slider("Max Texture Size", maxTextureSize, 1, 8192);
        mipMapLevel = EditorGUILayout.Slider("Mip Map Level", mipMapLevel, 1, 8192);

        overrideTexturesForAndroid = EditorGUILayout.BeginToggleGroup("Override Texture Settings For Android", overrideTexturesForAndroid);
        androidMaxTextureSize = EditorGUILayout.Slider("Max Texture Size", androidMaxTextureSize, 1, 8192);
        androidMipMapLevel = EditorGUILayout.Slider("Mip Map Level", androidMipMapLevel, 1, 8192);
        EditorGUILayout.EndToggleGroup();

        overrideAudioForAndroid = EditorGUILayout.BeginToggleGroup("Override Audio Settings For Android", overrideAudioForAndroid);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        bool buttonWasPressed = GUILayout.Button("Hello World");
        if (buttonWasPressed)
        {

            Debug.Log("Hello World!");
        }
    }
}