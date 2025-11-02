using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance { get; private set; }
    public Slider transparencySlider;
    public Toggle flipXToggle;
    public Toggle flipYToggle;
    public TMP_InputField positionXInput;
    public TMP_InputField positionYInput;
    
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
        if (positionXInput.text == "" || positionYInput.text == "")
        {
            positionXInput.text = 
                (positionXInput.text == "" ? settingData.position.x.ToString() : positionXInput.text);
            positionYInput.text = 
                (positionYInput.text == "" ? settingData.position.y.ToString() : positionYInput.text);
        }
        settingData.position = new Vector3(float.Parse(positionXInput.text), float.Parse(positionYInput.text), 0);
    }

    public void LoadSettingData()
    {
        tempSettingData = settingData;
        transparencySlider.value = tempSettingData.transparency;
        flipXToggle.isOn = tempSettingData.flipX;
        flipYToggle.isOn = tempSettingData.flipY;
        positionXInput.text = tempSettingData.position.x.ToString();
        positionYInput.text = tempSettingData.position.y.ToString();
    }
}

public struct SettingData
{
    public float transparency;
    public bool flipX;
    public bool flipY;
    public Vector3 position;
}