using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    public bool cont;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy )
            {
                NextLine();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());

            }
        }

        if(dialogueText.text == dialogue[index])
        {
            cont = true;
        }
    }

    public void clearText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        StopAllCoroutines();

    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        cont = false;

        if (index < dialogue.Length-1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            clearText();

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            clearText();
        }
    }
}
