#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEditor.Presets;

class AssetImporterEditorWindow : EditorWindow
{
    Vector2 scrollPos;

    bool overrideTexturesForAndroid = true;
    bool overrideAudioForAndroid = true;
    float mipMapLevel = 0;

    float androidMipMapLevel = 0;
    Preset preset = null;

    int maxTextureSizeSelected = 0;
    int maxTextureSizeSelectedForAndroid = 0;

    string[] maxTextureSizes = new string[]
    {
      "2", "4", "8", "16", "32", "64", "128", "256", "512", "1024", "2048"
    };

    [MenuItem("Window/Custom Asset Importer Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(AssetImporterEditorWindow));
    }
    private void OnGUI()
    {
        // Basic Editor Setup
        EditorGUILayout.BeginVertical();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(500));

        // Texture Settings
        GUILayout.Label("Texture Settings", EditorStyles.boldLabel);
        maxTextureSizeSelected = EditorGUILayout.Popup("Max Texture Size", maxTextureSizeSelected, maxTextureSizes);
        mipMapLevel = EditorGUILayout.Slider("Mip Map Level", mipMapLevel, 1, 8192);

        // Android Overrides
        overrideTexturesForAndroid = EditorGUILayout.BeginToggleGroup("Override Texture Settings For Android", overrideTexturesForAndroid);
        maxTextureSizeSelectedForAndroid = EditorGUILayout.Popup("Max Texture Size", maxTextureSizeSelectedForAndroid, maxTextureSizes);
        androidMipMapLevel = EditorGUILayout.Slider("Mip Map Level", androidMipMapLevel, 1, 8192);
        EditorGUILayout.EndToggleGroup();

        // Audio Settings
         /*a.compressionFormat = AudioCompressionFormat.PCM; // Can't be set to a format that Unity doesn't have
        a.sampleRateSetting = AudioSampleRateSetting.OptimizeSampleRate;
        a.loadType = AudioClipLoadType.CompressedInMemory;*/

        overrideAudioForAndroid = EditorGUILayout.BeginToggleGroup("Override Audio Settings For Android", overrideAudioForAndroid);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        bool buttonWasPressed = GUILayout.Button("Assign Import Settings");
        if (buttonWasPressed)
        {
            ImportProperties importProperties = (ImportProperties)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ImportProperties.prefab", typeof(ImportProperties));
            if (importProperties)
            {
                if (maxTextureSizeSelected >= 0)
                {
                    importProperties.textureSize = int.Parse(maxTextureSizes[maxTextureSizeSelected]);
                }

                importProperties.overrideTexturesForAndroid = overrideTexturesForAndroid;
                importProperties.overrideAudioForAndroid = overrideAudioForAndroid;
            }

            Debug.Log("Assigned Import Settings");
        }
    }
}
#endif