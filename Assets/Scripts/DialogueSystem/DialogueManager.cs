using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText1;
    public bool completedDialogue = false;

    [SerializeField]
    private DialogueBox dialogueBox;

    [SerializeField]
    private DialogueInteraction test; //Temperary so i can see in the editor
    [SerializeField]
    private Dictionary<int, string> test1;
    
    
    public void StartDialogue(DialogueInteraction dialogueInteraction)
    {
        if (!dialogueBox.isActiveAndEnabled)
        {
            test = dialogueInteraction;
            dialogueInteraction.PopulateData(); //Populates data before running
            dialogueBox.gameObject.SetActive(true); //activating dialogue box
            dialogueBox.dialogueManager = this;
            StartCoroutine(RunDialogue(dialogueInteraction.dialogues));
        }
    }

    private IEnumerator RunDialogue(Dialogue[] dialogues)
    {
        Dialogue currentDialogue;
        for (int i = 0; i < dialogues.Length; i++)
        {
            currentDialogue = dialogues[i];

            //Set name on the correct nametag
            nameText1.text = currentDialogue.name;

            //Set lines
            dialogueBox.lines = currentDialogue.sentences; //Setting sentences
            dialogueBox.StartDialogue(); //Starting dialogue
            yield return new WaitUntil(() => completedDialogue);
            completedDialogue = false;
        }
        dialogueBox.gameObject.SetActive(false);
    }
}
