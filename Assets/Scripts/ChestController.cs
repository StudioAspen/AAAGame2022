using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public bool inRange;

    public GameObject currentChest;
    public GameObject chestClosed;
    public GameObject chestOpen;

    public TMP_Text changeText;
    [TextAreaAttribute]
    public string text;

    void Update()
    {
        if(!(inRange) && isOpen)
            CloseChest();
        if (inRange && Input.GetKeyDown(KeyCode.E) && !(isOpen))
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
        changeText.text = text;
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
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
