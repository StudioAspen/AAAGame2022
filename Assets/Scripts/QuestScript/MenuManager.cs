using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        // If escape key is pressed, open/close quest menu
        if (Input.GetKeyDown(KeyCode.Escape))
            menu.gameObject.SetActive(!menu.gameObject.activeSelf);
    }
}