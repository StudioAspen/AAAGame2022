using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCollisionRemove : MonoBehaviour
{
    public Quest first_quest;

    private void OnTriggerEnter(Collider other)
    {
        //you have no quest in your list
        if (FindObjectOfType<QuestManager>().all_quests.Count == 0)
        {
            Debug.Log("no quest in list");
        }

        //if quest is not completed and you have a quest
        else if (!(first_quest.is_complete))
        {
            Debug.Log(first_quest + " not completed");
        }
        //if quest is completed
        else if (first_quest.is_complete)
        {
            FindObjectOfType<QuestManager>().HandInQuest(first_quest);
            Debug.Log(first_quest + " handed in");
            FindObjectOfType<QuestManager>().RemoveQuest(first_quest);
            Debug.Log(first_quest + " removed, quest count: " + FindObjectOfType<QuestManager>().all_quests.Count);
        }
    }
}
