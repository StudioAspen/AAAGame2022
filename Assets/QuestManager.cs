using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> all_quests;

    public Quest ReturnQuest(Quest quest)
    {
        foreach (var i in all_quests)
        {
            if (quest.title == i.title)
                return i;
        }
        return quest;
    }

    public bool FindQuest(Quest quest)
    {
        foreach (var i in all_quests)
        {
            if (quest.title == i.title)
                return true;
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
            if (quest == i)
                quest.is_complete = true;
        }
    }

    public void HandInQuest(Quest quest)
    {
        foreach (var i in all_quests)
        {
            if (quest == i && quest.is_complete)
                quest.handed_in = true;
        }
    }
}
