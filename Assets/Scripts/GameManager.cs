using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField]
    private GameObject jesus;

    private SpriteRenderer jesusSR;
    [SerializeField]
    private Slider transparencySlider;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
        jesusSR = jesus.GetComponent<SpriteRenderer>();
    }

    public void SetTransparency()
    {
        Color setColor = jesusSR.color;
        setColor.a = transparencySlider.value;
        jesusSR.color = setColor;
    }
    private void Update()
    {
    }
}
