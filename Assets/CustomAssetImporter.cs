using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomAssetImporter : AssetPostprocessor
{
    void OnPreprocessAudio()
    {
        // Audio Settings
        AudioImporter audioImporter = assetImporter as AudioImporter;
        var a = audioImporter.defaultSampleSettings;
        a.compressionFormat = AudioCompressionFormat.PCM; // Can't be set to a format that Unity doesn't have
        a.sampleRateSetting = AudioSampleRateSetting.OptimizeSampleRate;
        a.loadType = AudioClipLoadType.CompressedInMemory;
    }

    void OnPreprocessTexture()
    {
        TextureImporter textureImporter = assetImporter as TextureImporter;
        textureImporter.maxTextureSize = 512;
    }
}
