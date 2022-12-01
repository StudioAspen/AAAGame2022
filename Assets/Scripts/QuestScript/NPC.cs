using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Quest quest_;
    public DialogueInteraction action;
    DialogueManager dialogue_manager;

    private void Start()
    {
        quest_ = new Quest();
        quest_.title = "test name";
        quest_.description = "test description";
        dialogue_manager = FindObjectOfType<DialogueManager>();
    }

    public void CompleteQuest()
    {
        quest_.is_complete = true;
    }

    private IEnumerator IsDialogueBoxInactive()
    {
        //Showing menu after dialogue is completed
        yield return new WaitUntil(() => !dialogue_manager.dialogueBox.isActiveAndEnabled);
        ShowQuest();
    }

    public void Interact()
    {
        dialogue_manager.StartDialogue(action);
        StartCoroutine(IsDialogueBoxInactive());
    }


    public void ShowQuest()
    {
        QuestManager manager;
        manager = FindObjectOfType<QuestManager>();

        SingleQuestDisplay display;
        display = FindObjectOfType<SingleQuestDisplay>(true);

        //if quest is not there display title+des
        //with accept + reject button
        if (!(manager.FindQuest(quest_)))
        {
            display.DisplayAcceptReject();
            display.DisplayQuest(quest_);
        }

        //if quest is there but not completed
        //display quest title+des
        //have abandon quest method/button
        //abandon removes quest from list
        else if (manager.FindQuest(quest_) && (quest_.is_complete == false))
        {
            display.DisplayAbandon();
            display.DisplayQuest(quest_);
        }

        //if quest is there but completed
        //display the quest title+des
        //have a hand in button for quest
        else if (manager.FindQuest(quest_) && (quest_.is_complete == true) && (quest_.handed_in == false))
        {
            display.DisplayHandIn();
            display.DisplayQuest(quest_);
        }

        //if quest is there but handedin is true
        //debug.log("quest is done")
        //dialogue maybe
        else if (manager.FindQuest(quest_) && (quest_.handed_in == true))
        {
            Debug.Log("quest is done");
        }

    }
}
