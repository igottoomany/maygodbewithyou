using System;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuScrollview;

    private void Start()
    {
        TransparentWindow.Instance.isMenuOpen = MenuScrollview.activeSelf;
    }

    private void OnMouseUpAsButton()
    {
        MenuScrollview.SetActive(!MenuScrollview.activeSelf);
        TransparentWindow.Instance.isMenuOpen = MenuScrollview.activeSelf;
    }
}
