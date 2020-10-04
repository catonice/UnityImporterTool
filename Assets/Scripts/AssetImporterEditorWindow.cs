#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEditor.Presets;

class AssetImporterEditorWindow : EditorWindow
{
    Vector2 scrollPos;

    // Texture Settings
    int maxTextureSizeSelected = 0;
    float mipMapLevel = 0;
    // Android Texture Settings
    bool overrideTexturesForAndroid = true;
    float androidMipMapLevel = 0;
    int maxTextureSizeSelectedForAndroid = 0;

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
        // Basic Editor Setup
        EditorGUILayout.BeginVertical();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(500));

        // Texture Settings
        GUILayout.Label("Texture Import Settings", EditorStyles.boldLabel);
        maxTextureSizeSelected = EditorGUILayout.Popup("Max Texture Size", maxTextureSizeSelected, maxTextureSizes);
        //mipMapLevel = EditorGUILayout.Slider("Mip Map Level", mipMapLevel, 1, 8192);

        // Android Overrides
        overrideTexturesForAndroid = EditorGUILayout.BeginToggleGroup("Override Texture Settings For Android", overrideTexturesForAndroid);
        maxTextureSizeSelectedForAndroid = EditorGUILayout.Popup("Max Texture Size", maxTextureSizeSelectedForAndroid, maxTextureSizes);
        androidMipMapLevel = EditorGUILayout.Slider("Mip Map Level", androidMipMapLevel, 1, 8192);
        EditorGUILayout.EndToggleGroup();

        // Audio Settings
        GUILayout.Label("Audio Import Settings", EditorStyles.boldLabel);
        audioCompressionFormat = (AudioCompressionFormat)EditorGUILayout.EnumPopup("Audio Compression Format", audioCompressionFormat);
        audioSampleRateSetting = (AudioSampleRateSetting)EditorGUILayout.EnumPopup("Audio Sample Rate Setting", audioSampleRateSetting);
        audioClipLoadType = (AudioClipLoadType)EditorGUILayout.EnumPopup("Audio Clip Load Type", audioClipLoadType);

        overrideAudioForAndroid = EditorGUILayout.BeginToggleGroup("Override Audio Settings For Android", overrideAudioForAndroid);
        audioCompressionFormatForAndroid = (AudioCompressionFormat)EditorGUILayout.EnumPopup("Audio Compression Format", audioCompressionFormatForAndroid);
        audioSampleRateSettingForAndroid = (AudioSampleRateSetting)EditorGUILayout.EnumPopup("Audio Sample Rate Setting", audioSampleRateSettingForAndroid);
        audioClipLoadTypeForAndroid = (AudioClipLoadType)EditorGUILayout.EnumPopup("Audio Clip Load Type", audioClipLoadTypeForAndroid);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        bool buttonWasPressed = GUILayout.Button("Assign Import Settings");

        if (buttonWasPressed)
        {
            ImportProperties importProperties = (ImportProperties)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ImportProperties.prefab", typeof(ImportProperties));
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