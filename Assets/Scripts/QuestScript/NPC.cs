using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public Quest quest_;
    public DialogueInteraction action;

    private void Start()
    {
        quest_ = new Quest();
        quest_.title = "test name";
        quest_.description = "test description";
    }

    public void CompleteQuest()
    {
        quest_.is_complete = true;
    }

    public void Interact()
    {
        UnityEvent afterDialogue = new UnityEvent();
        afterDialogue.AddListener(ShowQuest);
        DialogueManager.Instance.StartDialogue(action, afterDialogue);
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
