using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> all_quests = new List<Quest>();
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            PrintQuests();
        }
    }
    public bool FindQuest(Quest quest)
    {
        foreach (var i in all_quests)
        {
            if (quest.title == i.title)
            {
                //Debug.Log("QuestManager: quest found");
                //The message does run twice, but nothing is broken
                return true;
            }
        }
        return false;
    }

    public void AddQuest(Quest quest)
    {
        all_quests.Add(quest);
    }

    public void RemoveQuest(Quest quest)
    {
        all_quests.Remove(quest);
    }

    public void CompleteQuest(Quest quest)
    {
        foreach (var i in all_quests)
        {
            if (quest.title == i.title)
            {
                i.is_complete = true;
                //Debug.Log(i.title + " is complete QM");
            }
        }
    }

    public void HandInQuest(Quest quest)
    {
        foreach (var i in all_quests)
        {
            if (quest == i && quest.is_complete)
            {
                quest.handed_in = true;
                //Debug.Log("QuestManager: quest handed in");
            }
        }
    }
    public void PrintQuests()
    {
        foreach(var quest in all_quests)
        {
            Debug.Log(quest.title + quest.is_complete + quest.handed_in);
        }
    }
}
