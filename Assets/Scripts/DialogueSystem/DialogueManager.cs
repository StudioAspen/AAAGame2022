using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public bool completedDialogue = false;

    [SerializeField]
    public DialogueBox dialogueBox;

    private void Awake() {
        Instance = this;
    }

    public void StartDialogue(DialogueInteraction dialogueInteraction, UnityEvent actionAfterDialogue = null)
    {
        if (!dialogueBox.isActiveAndEnabled)
        {
            dialogueBox.gameObject.SetActive(true); 
            
            if (actionAfterDialogue == null)
            {
                StartCoroutine(RunDialogue(dialogueInteraction.dialogues));
            }
            else 
            {
                StartCoroutine(RunDialogue(dialogueInteraction.dialogues, actionAfterDialogue));
            }
        }
    }

    private IEnumerator RunDialogue(Dialogue[] dialogues, UnityEvent actionAfterDialogue = null)
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogueBox.currentDialogue = dialogues[i];
            dialogueBox.StartDialogue();
            yield return new WaitUntil(() => completedDialogue);
            completedDialogue = false;
        }

        dialogueBox.gameObject.SetActive(false);
        if (actionAfterDialogue != null)
        {
            actionAfterDialogue.Invoke();
        }
    }
}
