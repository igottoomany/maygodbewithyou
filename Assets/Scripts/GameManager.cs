using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField]
    private Transform jesus;

    private SpriteRenderer jesusSR;
    [SerializeField]
    private Slider transparencySlider;
    
    private SettingManager settingManager;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        jesusSR = jesus.GetComponent<SpriteRenderer>();
        settingManager = SettingManager.Instance;
        LoadSettingData();
    }

    public void SetTransparency()
    {
        Color setColor = jesusSR.color;
        setColor.a = settingManager.settingData.transparency;
        jesusSR.color = setColor;
    }

    public void SetFlipX()
    {
        Vector3 flipScale = jesus.localScale;
        if (settingManager.settingData.flipX)
        {
            while (flipScale.x > 0)
                flipScale.x *= -1;
        }
        else
        {
            while (flipScale.x < 0)
                flipScale.x *= -1;
        }
        jesus.localScale = flipScale;
    }
    public void SetFlipY()
    {
        Vector3 flipScale = jesus.localScale;
        if (settingManager.settingData.flipY)
        {
            while (flipScale.y > 0)
                flipScale.y *= -1;
        }
        else
        {
            while (flipScale.y < 0)
                flipScale.y *= -1;
        }
        jesus.localScale = flipScale;
    }
    
    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/settings" + ".settings";
        return saveFile;
    }
    public void SaveSettingData()
    {
        settingManager.UpdateSettingData();
        
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(settingManager.settingData, true));
    }

    public void LoadSettingData()
    {
        if (!File.Exists(SaveFileName()))
        {
            SaveSettingData();
        }
        string loadData = File.ReadAllText(SaveFileName());
        Debug.Log(loadData);
        settingManager.settingData = JsonUtility.FromJson<SettingData>(loadData);
        settingManager.LoadSettingData();
        SetTransparency();
        SetFlipX();
        SetFlipY();
    }
    private void Update()
    {
    }
}
