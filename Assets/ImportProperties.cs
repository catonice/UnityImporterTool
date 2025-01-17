﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ImportProperties : MonoBehaviour
{
    public bool enableCustomImportSetting = false;

    // Texture Settings
    public int maxTextureSizeSelected = 0;
    public int mipMapLevel = 0;

    // Android Texture Settings
    public bool overrideTexturesForAndroid = true;
    public int mipMapLevelForAndroid = 0;
    public int maxTextureSizeSelectedForAndroid = 0;

    // Audio Settings
    public AudioCompressionFormat audioCompressionFormat;
    public AudioSampleRateSetting audioSampleRateSetting;
    public AudioClipLoadType audioClipLoadType;

    // Android Audio Settings
    public bool overrideAudioForAndroid = false;
    public AudioCompressionFormat audioCompressionFormatForAndroid;
    public AudioSampleRateSetting audioSampleRateSettingForAndroid;
    public AudioClipLoadType audioClipLoadTypeForAndroid;
}
