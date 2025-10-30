using System;
using UnityEngine;

public class ButtonTest : MonoBehaviour
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

        sr.color = Color.gray4;
    }

    void OnMouseUp()
    {
        sr.color = Color.white;
    }
    
    void Update()
    {
        
    }
}
