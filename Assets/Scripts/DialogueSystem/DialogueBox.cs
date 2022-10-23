using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponents;
    [SerializeField]
    private float textSpeed;
    public DialogueManager dialogueManager;

    public string[] lines;
    private int index;

    // Update is called once per frame
    void Update()
    {
        //make it so that you can only click inside dialogue box to proceed to next dialogue
        if(Input.GetMouseButtonDown(1))
        {
            if (textComponents.text == lines[index])
            {
                NextLine();
            }     
            else
            {
                StopAllCoroutines();
                textComponents.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        textComponents.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponents.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            //Setting text
            textComponents.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        //if there is no next line close the dialogue box
        else
        {
            dialogueManager.completedDialogue = true;
        }
    }

}
