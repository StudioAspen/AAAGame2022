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
        Debug.Log(quest.title + "outside");
        foreach (var i in all_quests)
        {
            Debug.Log(i.title + "foreach");
            if (quest.title == i.title)
                i.is_complete = true;
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
    public void PrintQuests()
    {
        foreach(var quest in all_quests)
        {
            Debug.Log(quest.title);
        }
    }
}
