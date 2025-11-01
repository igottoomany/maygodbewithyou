using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance { get; private set; }
    public Slider transparencySlider;
    public Toggle flipXToggle;
    public Toggle flipYToggle;
    public SettingData settingData = new SettingData();
    private SettingData tempSettingData;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void UpdateSettingData()
    {
        settingData.transparency = transparencySlider.value;
        settingData.flipX = flipXToggle.isOn;
        settingData.flipY = flipYToggle.isOn;
    }

    public void LoadSettingData()
    {
        tempSettingData = settingData;
        transparencySlider.value = tempSettingData.transparency;
        flipXToggle.isOn = tempSettingData.flipX;
        flipYToggle.isOn = tempSettingData.flipY;
    }
}

public struct SettingData
{
    public float transparency;
    public bool flipX;
    public bool flipY;
}