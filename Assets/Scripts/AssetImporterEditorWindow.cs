﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEditor.Presets;

class AssetImporterEditorWindow : EditorWindow
{
    Vector2 scrollPos;

    bool enableCustomImportSettings = false;

    // Texture Settings
    int maxTextureSizeSelected = 0;
    int mipMapLevel = 0;

    // Android Texture Settings
    bool overrideTexturesForAndroid = true;
    int maxTextureSizeSelectedForAndroid = 0;
    int mipMapLevelForAndroid = 0;

    // Audio Settings
    AudioCompressionFormat audioCompressionFormat;
    AudioSampleRateSetting audioSampleRateSetting;
    AudioClipLoadType audioClipLoadType;

    // Android Audio Settings
    bool overrideAudioForAndroid = true;
    AudioCompressionFormat audioCompressionFormatForAndroid;
    AudioSampleRateSetting audioSampleRateSettingForAndroid;
    AudioClipLoadType audioClipLoadTypeForAndroid;

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
        // Grabbing game object which holds configuration
        ImportProperties importProperties = (ImportProperties)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ImportProperties.prefab", typeof(ImportProperties));

        // Basic Editor Setup
        EditorGUILayout.BeginVertical();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(300));

        // Boolean For Applying Editor Props
        GUILayout.Label("Enable Custom Import Settings", EditorStyles.boldLabel);
        enableCustomImportSettings = EditorGUILayout.Toggle("Enable Custom Import Settings", enableCustomImportSettings);

        // Add toggle for if user wants to apply their own import settings
        if (enableCustomImportSettings)
        {
            importProperties.enableCustomImportSetting = enableCustomImportSettings;
        }
        else
        {
            importProperties.enableCustomImportSetting = enableCustomImportSettings;
        }

        // Texture Settings
        GUILayout.Label("Texture Import Settings", EditorStyles.boldLabel);
        maxTextureSizeSelected = EditorGUILayout.Popup("Max Texture Size", maxTextureSizeSelected, maxTextureSizes);
        mipMapLevel = EditorGUILayout.IntField("Mip Map Level", mipMapLevel);

        // Android Texture Overrides
        overrideTexturesForAndroid = EditorGUILayout.BeginToggleGroup("Override Texture Settings For Android", overrideTexturesForAndroid);
        maxTextureSizeSelectedForAndroid = EditorGUILayout.Popup("Max Texture Size", maxTextureSizeSelectedForAndroid, maxTextureSizes);
        mipMapLevelForAndroid = EditorGUILayout.IntField("Mip Map Level", mipMapLevelForAndroid);
        EditorGUILayout.EndToggleGroup();

        // Audio Settings
        GUILayout.Label("Audio Import Settings", EditorStyles.boldLabel);
        audioCompressionFormat = (AudioCompressionFormat)EditorGUILayout.EnumPopup("Audio Compression Format", audioCompressionFormat);
        audioSampleRateSetting = (AudioSampleRateSetting)EditorGUILayout.EnumPopup("Audio Sample Rate Setting", audioSampleRateSetting);
        audioClipLoadType = (AudioClipLoadType)EditorGUILayout.EnumPopup("Audio Clip Load Type", audioClipLoadType);

        // Android Audio Overrides
        overrideAudioForAndroid = EditorGUILayout.BeginToggleGroup("Override Audio Settings For Android", overrideAudioForAndroid);
        audioCompressionFormatForAndroid = (AudioCompressionFormat)EditorGUILayout.EnumPopup("Audio Compression Format", audioCompressionFormatForAndroid);
        audioSampleRateSettingForAndroid = (AudioSampleRateSetting)EditorGUILayout.EnumPopup("Audio Sample Rate Setting", audioSampleRateSettingForAndroid);
        audioClipLoadTypeForAndroid = (AudioClipLoadType)EditorGUILayout.EnumPopup("Audio Clip Load Type", audioClipLoadTypeForAndroid);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        bool assignImportSettingsButton = GUILayout.Button("Assign Import Settings");

        if (assignImportSettingsButton)
        {
            if (importProperties)
            {
                // Texture Settings
                if (maxTextureSizeSelected >= 0)
                {
                    importProperties.maxTextureSizeSelected = int.Parse(maxTextureSizes[maxTextureSizeSelected]);
                }

                if (overrideTexturesForAndroid)
                {
                    importProperties.overrideTexturesForAndroid = overrideTexturesForAndroid;
                    importProperties.maxTextureSizeSelectedForAndroid = int.Parse(maxTextureSizes[maxTextureSizeSelectedForAndroid]);
                }

                // Audio Settings
                importProperties.audioCompressionFormat = audioCompressionFormat;
                importProperties.audioSampleRateSetting = audioSampleRateSetting;
                importProperties.audioClipLoadType = audioClipLoadType;

                if (overrideAudioForAndroid)
                {
                    importProperties.overrideAudioForAndroid = overrideAudioForAndroid;
                    importProperties.audioCompressionFormatForAndroid = audioCompressionFormatForAndroid;
                    importProperties.audioSampleRateSettingForAndroid = audioSampleRateSettingForAndroid;
                    importProperties.audioClipLoadTypeForAndroid = audioClipLoadTypeForAndroid;
                }
            }

            Debug.Log("Assigned Import Settings");
        }
    }
}
#endif