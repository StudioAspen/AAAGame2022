using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public bool inRange;
    public GameObject currentChest;
    public GameObject chestClosed;
    public GameObject chestOpen;

    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E) && !(isOpen))
        {
            OpenChest();
        }
        else if(inRange && Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            CloseChest();
        }
    }

    void OpenChest()
    {
        isOpen = true;
        Destroy(currentChest);
        currentChest = Instantiate(chestOpen, transform);
        FindInActiveObjectByName("ChestNote").SetActive(true);
    }

    void CloseChest()
    {
        isOpen = false;
        Destroy(currentChest);
        currentChest = Instantiate(chestClosed, transform);
        GameObject.Find("ChestNote").SetActive(false);
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
