using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] private GameObject tab;

    public void tabSwitch(GameObject tab)
    {
        if(tab.activeSelf == true)
        { 
            tab.SetActive(false); 
        }
        else
        {
            tab.SetActive(true);
        }

    }
}