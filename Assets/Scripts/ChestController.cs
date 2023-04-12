using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    bool isOpen;
    bool inRange;
    GameObject chestPanel;

    private void Start()
    {
            
    }

    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E) && !(isOpen))
        {
            FindInActiveObjectByName("ChestNote").SetActive(true);
            isOpen = true;
        }
        else if(inRange && Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            GameObject.Find("ChestNote").SetActive(false);
            isOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            Debug.Log("out of range");
        }
    }
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
