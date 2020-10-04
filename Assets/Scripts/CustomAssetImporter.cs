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
        ImportProperties importProperties = (ImportProperties)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ImportProperties.prefab", typeof(ImportProperties));
        TextureImporter textureImporter = assetImporter as TextureImporter;
        if (importProperties)
        {
            textureImporter.maxTextureSize = importProperties.textureSize;

            if (importProperties.overrideTexturesForAndroid)
            {
                Debug.Log("Override Android");
            }
        }
    }

    void OnPostprocessTexture(Texture2D texture)
    {
        //texture.minimumMipmapLevel = 1;
        // Only post process textures if they are in a folder
        // "invert color" or a sub folder of it.
        /*string lowerCaseAssetPath = assetPath.ToLower();
        if (lowerCaseAssetPath.IndexOf("/invert color/") == -1)
            return;
*/
       /* for (int m = 0; m < texture.mipmapCount; m++)
        {
            Color[] c = texture.GetPixels(m);

            for (int i = 0; i < c.Length; i++)
            {
                c[i].r = 1 - c[i].r;
                c[i].g = 1 - c[i].g;
                c[i].b = 1 - c[i].b;
            }
            texture.SetPixels(c, m);
        }*/
        // Instead of setting pixels for each mip map levels, you can also
        // modify only the pixels in the highest mip level. And then simply use
        // texture.Apply(true); to generate lower mip levels.
    }
}
