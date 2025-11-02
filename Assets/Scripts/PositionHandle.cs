using System;
using UnityEngine;

public class PositionHandle : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector3 screenPoint;
    private Vector3 offset;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = transform.parent.position -
                 Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.parent.position = curPosition;

        sr.color = new Color(0.4f, 0.4f, 0.4f, 0.5f); // gray 127 alpha
        SettingManager.Instance.settingData.position = transform.parent.position;
        SettingManager.Instance.LoadSettingData();
        GameManager.Instance.SetPosition();
    }

    void OnMouseUp()
    {
        sr.color = new Color(1f, 1f, 1f, 0.5f); // white 127 alpha
        GameManager.Instance.SaveSettingDataFile();
    }
}
