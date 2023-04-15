using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public bool completedDialogue = true;

    [SerializeField]
    public DialogueBox dialogueBox;
    private CharacterMovement characterMovement;

    private bool dialogueInterupt = false;

    private void Awake() {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && completedDialogue == false)
        {
            dialogueInterupt = true;
            completedDialogue = true;
        }
    }
    public void StartDialogue(DialogueInteraction dialogueInteraction, UnityEvent actionAfterDialogue = null)
    {
        if (!dialogueBox.isActiveAndEnabled)
        {
            completedDialogue = false;
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
        characterMovement = FindObjectOfType<CharacterMovement>();
        if(characterMovement != null)
        {
            characterMovement.canMove = false;
        }
    }
    private IEnumerator RunDialogue(Dialogue[] dialogues, UnityEvent actionAfterDialogue = null)
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            if(dialogueInterupt == true)
            {
                break;
            }
            dialogueBox.currentDialogue = dialogues[i];
            dialogueBox.StartDialogue();
            yield return new WaitUntil(() => completedDialogue);
            completedDialogue = false;
        }

        dialogueBox.portrait1.gameObject.SetActive(false);
        dialogueBox.portrait2.gameObject.SetActive(false);
        dialogueBox.gameObject.SetActive(false);
        dialogueInterupt = false;

        if (actionAfterDialogue != null)
        {
            actionAfterDialogue.Invoke();
        }
        characterMovement = FindObjectOfType<CharacterMovement>();
        if (characterMovement != null)
        {
            characterMovement.canMove = true;
        }
    }
}
