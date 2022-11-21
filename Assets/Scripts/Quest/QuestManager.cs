using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> list_quests = new List<Quest>();

    void AddQuest(Quest quest)
    {
        list_quests.Add(quest);
    }

    void RemoveQuest(Quest quest)
    {
        for(int i = 0; i < list_quests.Count; i++)
        {
            if (list_quests[i] = quest)
                list_quests.Remove(list_quests[i]);
        }
    }

    void CompleteQuest(Quest quest)
    {
        quest.gsCompleted = true;
    }

    void HandInQuest(Quest quest)
    {
        quest.gsHanded_in = true;
    }
}
