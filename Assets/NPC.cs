using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Quest quest_;
    public bool given_quest;
    

    public void Interact()
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
        else if (manager.FindQuest(quest_) && (quest_.is_complete == true))
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
