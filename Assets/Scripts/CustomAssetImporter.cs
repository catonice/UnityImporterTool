using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomAssetImporter : AssetPostprocessor
{
    void OnPreprocessAudio()
    {
        ImportProperties importProperties = (ImportProperties)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ImportProperties.prefab", typeof(ImportProperties));
        AudioImporter audioImporter = assetImporter as AudioImporter;
        var a = audioImporter.defaultSampleSettings;
        a.compressionFormat = importProperties.audioCompressionFormat;
        a.sampleRateSetting = importProperties.audioSampleRateSetting;
        a.loadType = importProperties.audioClipLoadType;

        audioImporter.defaultSampleSettings = a;

        // Override Android Import Settings
        if (importProperties.overrideAudioForAndroid)
        {
            AudioImporterSampleSettings settings = new AudioImporterSampleSettings();
            settings.compressionFormat = importProperties.audioCompressionFormatForAndroid;
            settings.sampleRateSetting = importProperties.audioSampleRateSettingForAndroid;
            settings.loadType = importProperties.audioClipLoadTypeForAndroid;

            audioImporter.SetOverrideSampleSettings("Android", settings);
        }
    }

    void OnPreprocessTexture()
    {
        ImportProperties importProperties = (ImportProperties)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ImportProperties.prefab", typeof(ImportProperties));
        TextureImporter textureImporter = assetImporter as TextureImporter;

        if (importProperties)
        {
            if (importProperties.maxTextureSizeSelected > 0)
            {
                textureImporter.maxTextureSize = importProperties.maxTextureSizeSelected;
            }

            if (importProperties.overrideTexturesForAndroid)
            {
                TextureImporterPlatformSettings androidSettings = textureImporter.GetPlatformTextureSettings("Android");
                androidSettings.overridden = true;
                androidSettings.maxTextureSize = importProperties.maxTextureSizeSelectedForAndroid;
                textureImporter.SetPlatformTextureSettings(androidSettings);

                Debug.Log("Override Android");
            }
        }
    }

    void OnPostprocessTexture(Texture2D texture)
    {
        ImportProperties importProperties = (ImportProperties)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ImportProperties.prefab", typeof(ImportProperties));
        TextureImporter textureImporter = assetImporter as TextureImporter;

        if (importProperties)
        {
            // TODO: Figure out setting mip map levels for platforms
            if (importProperties.mipMapLevel >= 0)
            {
                texture.requestedMipmapLevel = importProperties.mipMapLevel;
            }

            if (importProperties.overrideTexturesForAndroid && importProperties.mipMapLevelForAndroid >= 0)
            {
                TextureImporterPlatformSettings androidSettings = textureImporter.GetPlatformTextureSettings("Android");
                androidSettings.overridden = true;
                
                textureImporter.SetPlatformTextureSettings(androidSettings);
            }
        }
    }
}