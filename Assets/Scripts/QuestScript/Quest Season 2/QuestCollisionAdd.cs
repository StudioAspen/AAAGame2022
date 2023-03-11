using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCollisionAdd : MonoBehaviour
{
    public Quest first_quest;

    private void OnTriggerEnter(Collider other)
    {
        //if quest added already
        if(FindObjectOfType<QuestManager>().FindQuest(first_quest))
        {
            Debug.Log(first_quest + " added already");
        }
        //quest has not been added
        if (!(FindObjectOfType<QuestManager>().FindQuest(first_quest))) {
            FindObjectOfType<QuestManager>().AddQuest(first_quest);
            Debug.Log(first_quest + " added, quest count " + FindObjectOfType<QuestManager>().all_quests.Count);
        }
    }
}
