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
    public TMP_InputField sizeXInput;
    public TMP_InputField sizeYInput;
    
    
    public SettingData settingData = new SettingData();
    public SettingData defaultSettingData = new SettingData(1f, false, false, 
        new Vector3(9f, -5f, 0), new Vector3(0.07f, 0.07f, 1f));
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
        
        //position
        try
        {
            settingData.position = new Vector3(float.Parse(positionXInput.text), float.Parse(positionYInput.text), 0);
        } 
        catch
        {
            Debug.Log(settingData.position.x + " " + settingData.position.y + " " + settingData.position.z);
        }
        
        //size 
        try
        {
            settingData.size = new Vector3(float.Parse(sizeXInput.text), float.Parse(sizeYInput.text), 0);
        }
        catch
        {
            Debug.Log(settingData.size.x + " " + settingData.size.y + " " + settingData.size.z);
        }
    }

    public void LoadSettingData()
    {
        tempSettingData = settingData;
        transparencySlider.value = tempSettingData.transparency;
        flipXToggle.isOn = tempSettingData.flipX;
        flipYToggle.isOn = tempSettingData.flipY;
        positionXInput.text = tempSettingData.position.x.ToString();
        positionYInput.text = tempSettingData.position.y.ToString();
        sizeXInput.text = tempSettingData.size.x.ToString();
        sizeYInput.text = tempSettingData.size.y.ToString();
    }

    public void SetDefalutSetting()
    {
        settingData = defaultSettingData;
        LoadSettingData();
    }
}

public struct SettingData
{
    public float transparency;
    public bool flipX;
    public bool flipY;
    public Vector3 position;
    public Vector3 size;

    public SettingData(float transparency, bool flipX, bool flipY, Vector3 position, Vector3 size)
    {
        this.transparency = transparency;
        this.flipX = flipX;
        this.flipY =  flipY;
        this.position = position;
        this.size = size;
    }
}