using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTest : MonoBehaviour
{
    //Quest quest;
    //QuestManager questManager;
    DialogueManager dialogueManager;
    public NPCQuestDisplay questDisplay;

    //State Machine for quests
    enum QuestState
    {
        NOT_GIVEN,
        GIVEN,
        HANDED_IN
    }

    QuestState questState = QuestState.NOT_GIVEN;

    //Dialogues for different quest states
    [SerializeField]
    private DialogueInteraction beforeQuest;
    [SerializeField]
    private DialogueInteraction givenQuest;
    [SerializeField]
    private DialogueInteraction completedQuest;

    // Start is called before the first frame update
    void Start()
    {
        //questManager = FindObjectOfType<QuestManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        questDisplay = FindObjectOfType<NPCQuestDisplay>(true);
        
    }

    public void Interact() //Player interacting with NPC
    {
        //State machine for quest status
        DialogueInteraction playingDialogue = null;
        bool showQuestDisplay = false;
        switch (questState) {
            case QuestState.NOT_GIVEN:
                playingDialogue = beforeQuest;
                showQuestDisplay = true;
                break;
            case QuestState.GIVEN:
                playingDialogue = givenQuest;
                showQuestDisplay = true;
                break;
            case QuestState.HANDED_IN:
                playingDialogue = completedQuest;
                break;
        }

        dialogueManager.StartDialogue(playingDialogue);
        if (showQuestDisplay)
        {
            StartCoroutine(IsDialogueBoxInactive());
        }
    }
    private IEnumerator IsDialogueBoxInactive()
    {
        //Showing menu after dialogue is completed
        yield return new WaitUntil (() => !dialogueManager.dialogueBox.isActiveAndEnabled);
        ShowQuest();
    }
    public void ShowQuest()
    {
        questDisplay.gameObject.SetActive(true);

        //Adding listeners for buttons
        questDisplay.accept.onClick.AddListener(GiveQuest);
        
        //Only set active if youve gotten quest
        if (questState == QuestState.GIVEN)
        {
            questDisplay.handIn.gameObject.SetActive(true);
            questDisplay.handIn.onClick.AddListener(HandInQuest);
        }
        else
        {
            questDisplay.handIn.gameObject.SetActive(false);
        }

        //Setting information in display
        questDisplay.title.text = "test title"; //quest.title;
        questDisplay.description.text = "test description test test test test test test test test test test test test test test test test test test test test"; //quest.description;
    }

    public void GiveQuest()
    {
        //questManager.GiveQuest(quest);
        questState = QuestState.GIVEN;
        questDisplay.CloseMenu();
    }
    public void HandInQuest()
    {
        //questManager.CompleteQuest(quest);
        //Give Rewards
        questState = QuestState.HANDED_IN;
        questDisplay.CloseMenu();
    }
}
