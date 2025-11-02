using System;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject Obj;
    private Vector3 pos;
    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()   
    {
        if (Obj)
        {
            pos = RectTransformUtility.WorldToScreenPoint(Camera.main, Obj.transform.position);
            rt.position = pos;
        }
    }
}
