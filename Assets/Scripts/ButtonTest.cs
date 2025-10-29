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

        offset = transform.parent.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.parent.position = curPosition;

    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPos = new Vector2(worldPos.x, worldPos.y);
            Collider2D col = Physics2D.OverlapPoint(clickPos);
            if (col.gameObject.Equals(gameObject))
            {
                sr.color = sr.color.Equals(Color.black) ? Color.white : Color.black;
            }
        }
    }
}
