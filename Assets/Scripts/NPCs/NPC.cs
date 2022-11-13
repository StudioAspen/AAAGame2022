using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //Quest quest;
    //QuestManager questManager;
    DialogueManager dialogueManager;
    public NPCQuestDisplay questDisplay;

    //State Machine
    enum QuestState
    {
        NOT_GIVEN,
        GIVEN,
        HANDED_IN
    }

    QuestState questState = QuestState.NOT_GIVEN;

    //Dialogues
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
        //questDisplay = FindObjectOfType<NPCQuestDisplay>();
        
    }

    public void Interact() //Player interacting with NPC
    {
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
        Debug.Log("start coroutine");
        yield return new WaitUntil (() => !dialogueManager.dialogueBox);
        Debug.Log("after wait");
        ShowQuest();
    }
    public void ShowQuest()
    {
        Debug.Log("showing quest");
        questDisplay.gameObject.SetActive(true);
        questDisplay.accept.onClick.AddListener(GiveQuest);
        questDisplay.title.text = "test title"; //quest.title;
        questDisplay.description.text = "test description test test test test test test test test test test test test test test test test test test test test"; //quest.description;
        
        //Only set active if youve gotten quest
        if (questState == QuestState.HANDED_IN)
        {
            questDisplay.handIn.onClick.AddListener(HandInQuest);
        }
        else
        {
            questDisplay.handIn.gameObject.SetActive(false);
        }
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
